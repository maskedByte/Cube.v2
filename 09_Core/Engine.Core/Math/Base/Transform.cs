// ReSharper disable CompareOfFloatsByEqualityOperator

using System.Diagnostics.Contracts;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Quaternions;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Base;

/// <summary>
///     Implementation of <see cref="Transform" />
/// </summary>
[Serializable]
public sealed class Transform
{
    private bool _dirty;
    private Vector3 _localPosition;
    private Matrix4 _localPositionMatrix;
    private Quaternion _localRotation;
    private Matrix4 _localRotationMatrix;
    private Matrix4 _modelMatrix; // Cached
    private Vector3 _origin;
    private Matrix4 _originMatrix;

    private Vector3 _scale;

    // Cached matrix
    private Matrix4 _scaleMatrix;

    /// <summary>
    ///     Set to true to automatically update the model matrix
    /// </summary>
    public bool AutoRecalculate { get; set; } = true;

    /// <summary>
    ///     Gets or sets a parent transform
    /// </summary>
    public Transform? Parent { get; set; }

    /// <summary>
    ///     World-Space Position vector
    /// </summary>
    public Vector3 Position
    {
        get => _modelMatrix.ExtractTranslation();
        set => LocalPosition = value;
    }

    /// <summary>
    ///     Local-Space Position vector
    /// </summary>
    public Vector3 LocalPosition
    {
        get => _localPosition;
        set
        {
            _localPosition = value;
            _localPositionMatrix = Matrix4.CreateTranslation(LocalPosition);
            SetDirty();
        }
    }

    /// <summary>
    ///     World-Space Rotation Quaternion
    /// </summary>
    public Quaternion Rotation
    {
        get => _modelMatrix.ExtractRotation();
        set
        {
            LocalRotation = value;
            SetDirty();
        }
    }

    /// <summary>
    ///     Local-Space Rotation Quaternion
    /// </summary>
    public Quaternion LocalRotation
    {
        get => _localRotation;
        set
        {
            _localRotation = value;
            _localRotationMatrix = Matrix4.CreateFromQuaternion(_localRotation);
            SetDirty();
        }
    }

    /// <summary>
    ///     Scale Vector
    /// </summary>
    public Vector3 Scale
    {
        get => _modelMatrix.ExtractScale();
        set
        {
            _scale = value;
            _scaleMatrix = Matrix4.CreateScale(_scale);
            SetDirty();
        }
    }

    /// <summary>
    ///     Returns the calculated model matrix
    /// </summary>
    public Matrix4 Transformation
    {
        get
        {
            CalculateMatrix();
            return _modelMatrix;
        }
    }

    /// <summary>
    ///     Set an vector as origin
    /// </summary>
    public Vector3 Origin
    {
        get => _origin;
        set
        {
            _origin = value;
            _originMatrix = Matrix4.CreateTranslation(_origin);
            SetDirty();
        }
    }

    /// <summary>
    ///     Get the forward vector based on the camera transform
    /// </summary>
    public Vector3 Forward => Vector3.Transform(-Vector3.Forward, Rotation);

    /// <summary>
    ///     Get the right vector based on the camera transform
    /// </summary>
    public Vector3 Up => Vector3.Transform(Vector3.Up, Rotation);

    /// <summary>
    ///     Get the right vector based on the camera transform
    /// </summary>
    public Vector3 Right => Vector3.Transform(Vector3.Right, Rotation);

    /// <summary>
    ///     Creates a new instance of <see cref="Transform" />
    /// </summary>
    public Transform()
    {
        LocalPosition = Vector3.Zero;
        LocalRotation = Quaternion.Identity;
        Scale = Vector3.One;
        Origin = Vector3.Zero;

        _modelMatrix = Matrix4.Identity;

        Parent = null;
        _dirty = true;
        CalculateMatrix();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Transform" /> and sets its position.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    public Transform(Vector3 position)
        : this()
    {
        LocalPosition = position;
        CalculateMatrix();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Transform" /> and sets its position and scale.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    public Transform(Vector3 position, Vector3 scale)
        : this(position)
    {
        Scale = scale;
        Origin = Vector3.Zero;
        CalculateMatrix();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Transform" /> and sets its position, scale and rotation.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    /// <param name="rotation">The initial rotation to set for the transform.</param>
    public Transform(Vector3 position, Vector3 scale, Quaternion rotation)
        : this(position, scale)
    {
        Rotation = rotation;
        Origin = Vector3.Zero;
        CalculateMatrix();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Transform" /> and sets its position, scale, rotation and origin.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    /// <param name="rotation">The initial rotation to set for the transform.</param>
    /// <param name="origin">The initial origin to set for the transform.</param>
    public Transform(
        Vector3 position,
        Vector3 scale,
        Quaternion rotation,
        Vector3 origin
    )
        : this(position, scale, rotation)
    {
        Origin = origin;
        CalculateMatrix();
    }

    /// <summary>
    ///     Translate into specific direction given by <paramref name="translation" />
    /// </summary>
    /// <param name="translation"></param>
    /// <param name="space"></param>
    public void Translate(Vector3 translation, CoordinateSpace space = CoordinateSpace.World)
    {
        switch (space)
        {
            case CoordinateSpace.World:
                Position += translation;
                break;
            case CoordinateSpace.Local:
                LocalPosition += Rotation * translation;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(space), space, null);
        }
    }

    /// <summary>
    ///     Rotates the transform by the specified Euler angles in the specified coordinate space.
    /// </summary>
    /// <param name="euler">The Euler angles (in degrees) to rotate by.</param>
    /// <param name="space">The coordinate space in which to apply the rotation (Local or World).</param>
    public void Rotate(Vector3 euler, CoordinateSpace space)
    {
        var eulerRot = Quaternion.FromEulerAngles(euler.X, euler.Y, euler.Z);
        if (space == CoordinateSpace.Local)
        {
            LocalRotation *= eulerRot;
        }
        else
        {
            Rotation *= Quaternion.Invert(Rotation) * eulerRot * Rotation;
        }
    }

    /// <summary>
    ///     Rotates the transform by the specified Euler angles in the local coordinate space.
    /// </summary>
    /// <param name="euler">The Euler angles (in degrees) to rotate by.</param>
    public void Rotate(Vector3 euler) => Rotate(euler, CoordinateSpace.Local);

    /// <summary>
    ///     Rotates the transform by the specified Euler angles in the specified coordinate space.
    /// </summary>
    /// <param name="xAngle">The rotation angle around the X-axis (in degrees).</param>
    /// <param name="yAngle">The rotation angle around the Y-axis (in degrees).</param>
    /// <param name="zAngle">The rotation angle around the Z-axis (in degrees).</param>
    /// <param name="relativeTo">The coordinate space in which to apply the rotation (Local or World).</param>
    public void Rotate(float xAngle, float yAngle, float zAngle, CoordinateSpace relativeTo) =>
        Rotate(new Vector3(xAngle, yAngle, zAngle), relativeTo);

    /// <summary>
    ///     Rotates the transform by the specified Euler angles in the local coordinate space.
    /// </summary>
    /// <param name="xAngle">The rotation angle around the X-axis (in degrees).</param>
    /// <param name="yAngle">The rotation angle around the Y-axis (in degrees).</param>
    /// <param name="zAngle">The rotation angle around the Z-axis (in degrees).</param>
    public void Rotate(float xAngle, float yAngle, float zAngle) => Rotate(new Vector3(xAngle, yAngle, zAngle), CoordinateSpace.Local);

    /// <summary>
    ///     Calculate the distance between this object and another objects positions
    /// </summary>
    /// <param name="transform">The target <see cref="Transform" /> to calculate distance to.</param>
    /// <returns></returns>
    [Pure]
    public float Distance(in Transform transform) => Vector3.Distance(Position, transform.Position);

    private void CalculateMatrix()
    {
        if (!_dirty && Parent == null)
        {
            return;
        }

        _modelMatrix = Matrix4.Identity;

        // World transformation
        if (Parent != null)
        {
            _modelMatrix *= Parent.Transformation;
        }

        _modelMatrix = _scaleMatrix * _originMatrix.Inverted() * _localRotationMatrix * _originMatrix * _localPositionMatrix * _modelMatrix;

        _dirty = false;
    }

    private void SetDirty() => _dirty = AutoRecalculate;
}
