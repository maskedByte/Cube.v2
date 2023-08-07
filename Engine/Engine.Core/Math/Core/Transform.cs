// ReSharper disable CompareOfFloatsByEqualityOperator

using Engine.Math.Enum;
using Engine.Math.Matrix;
using Engine.Math.Vector;

namespace Engine.Math.Core;

/// <summary>
/// Implementation of <see cref="Transform" />
/// </summary>
[Serializable]
public sealed class Transform
{
    private bool _dirty;
    private Vector3 _localPosition;
    private Matrix4 _localPositionMatrix;
    private Quaternion.Quaternion _localRotation;
    private Matrix4 _localRotationMatrix;
    private Matrix4 _modelMatrix; // Cached
    private Vector3 _origin;
    private Matrix4 _originMatrix;

    private Vector3 _scale;

    // Cached matrix
    private Matrix4 _scaleMatrix;

    /// <summary>
    /// Set to true to automatically update the model matrix
    /// </summary>
    public bool AutoRecalculate { get; set; } = true;

    /// <summary>
    /// Gets or sets a parent transform
    /// </summary>
    public Transform? Parent { get; set; }

    /// <summary>
    /// World-Space Position vector
    /// </summary>
    public Vector3 Position
    {
        get
        {
            return Parent != null
                ? _localPosition + Parent.Position
                : _localPosition;
        }
        set { LocalPosition = value; }
    }

    /// <summary>
    /// Local-Space Position vector
    /// </summary>
    public Vector3 LocalPosition
    {
        get { return _localPosition; }
        set
        {
            _localPosition = value;
            _localPositionMatrix = Matrix4.CreateTranslation(LocalPosition);
            SetDirty();
        }
    }

    /// <summary>
    /// World-Space Rotation Quaternion
    /// </summary>
    public Quaternion.Quaternion Rotation
    {
        get
        {
            return Parent != null
                ? _localRotation * Parent.Rotation
                : _localRotation;
        }
        set
        {
            LocalRotation = value;
            SetDirty();
        }
    }

    /// <summary>
    /// Local-Space Rotation Quaternion
    /// </summary>
    public Quaternion.Quaternion LocalRotation
    {
        get { return _localRotation; }
        set
        {
            _localRotation = value;
            _localRotationMatrix = Matrix4.CreateFromQuaternion(_localRotation);
            SetDirty();
        }
    }

    /// <summary>
    /// Scale Vector
    /// </summary>
    public Vector3 Scale
    {
        get { return _scale; }
        set
        {
            _scale = value;
            _scaleMatrix = Matrix4.CreateScale(_scale);
            SetDirty();
        }
    }

    /// <summary>
    /// Returns the calculated model matrix
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
    /// Set an vector as origin
    /// </summary>
    public Vector3 Origin
    {
        get { return _origin; }
        set
        {
            _origin = value;
            _originMatrix = Matrix4.CreateTranslation(_origin);
            SetDirty();
        }
    }

    /// <summary>
    /// Creates a new instance of <see cref="Transform" />
    /// </summary>
    public Transform()
    {
        LocalPosition = Vector3.Zero;
        LocalRotation = Quaternion.Quaternion.Identity;
        Scale = Vector3.One;
        Origin = Scale * 0.5f;

        _modelMatrix = Matrix4.Identity;

        Parent = null;
        _dirty = true;
        CalculateMatrix();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Transform" /> and sets its position.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    public Transform(Vector3 position)
        : this()
    {
        LocalPosition = position;
        CalculateMatrix();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Transform" /> and sets its position and scale.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    public Transform(Vector3 position, Vector3 scale)
        : this(position)
    {
        Scale = scale;
        Origin = scale * 0.5f;
        CalculateMatrix();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Transform" /> and sets its position, scale and rotation.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    /// <param name="rotation">The initial rotation to set for the transform.</param>
    public Transform(Vector3 position, Vector3 scale, Quaternion.Quaternion rotation)
        : this(position, scale)
    {
        Rotation = rotation;
        Origin = scale * 0.5f;
        CalculateMatrix();
    }

    /// <summary>
    /// Creates a new instance of <see cref="Transform" /> and sets its position, scale, rotation and origin.
    /// </summary>
    /// <param name="position">The initial position to set for the transform.</param>
    /// <param name="scale">The initial scale to set for the transform.</param>
    /// <param name="rotation">The initial rotation to set for the transform.</param>
    /// <param name="origin">The initial origin to set for the transform.</param>
    public Transform(Vector3 position, Vector3 scale, Quaternion.Quaternion rotation, Vector3 origin)
        : this(position, scale, rotation)
    {
        Origin = origin;
        CalculateMatrix();
    }

    /// <summary>
    /// Translate into specific direction given by <paramref name="translation" />
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
    /// Calculate the distance between this object and another objects positions
    /// </summary>
    /// <param name="transform">The target <see cref="Transform" /> to calculate distance to.</param>
    /// <returns></returns>
    public float Distance(Transform transform)
    {
        return Vector3.Distance(Position, transform.Position);
    }

    private void CalculateMatrix()
    {
        if (!_dirty && Parent == null) return;

        _modelMatrix = Matrix4.Identity;

        if (Parent != null)
            // World transformation
            _modelMatrix *= Parent.Transformation;

        _modelMatrix = _scaleMatrix *
                       _originMatrix.Inverted() *
                       _localRotationMatrix *
                       _originMatrix *
                       _localPositionMatrix *
                       _modelMatrix;

        _dirty = false;
    }

    private void SetDirty()
    {
        _dirty = AutoRecalculate;
    }
}
