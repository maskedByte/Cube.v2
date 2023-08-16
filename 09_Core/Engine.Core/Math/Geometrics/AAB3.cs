using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Geometrics;

/// <summary>
///     Defines an axis-aligned 3d box (rectangular prism).
/// </summary>
[StructLayout(LayoutKind.Sequential), Serializable]
public struct AAB3 : IEquatable<AAB3>
{
    private Vector3 _min;

    /// <summary>
    ///     Gets or sets the minimum boundary of the structure.
    /// </summary>
    public Vector3 Min
    {
        get => _min;
        set
        {
            if (value.X > _max.X)
            {
                _max.X = value.X;
            }

            if (value.Y > _max.Y)
            {
                _max.Y = value.Y;
            }

            if (value.Z > _max.Z)
            {
                _max.Z = value.Z;
            }

            _min = value;
        }
    }

    private Vector3 _max;

    /// <summary>
    ///     Gets or sets the maximum boundary of the structure.
    /// </summary>
    public Vector3 Max
    {
        get => _max;
        set
        {
            if (value.X < _min.X)
            {
                _min.X = value.X;
            }

            if (value.Y < _min.Y)
            {
                _min.Y = value.Y;
            }

            if (value.Z < _min.Z)
            {
                _min.Z = value.Z;
            }

            _max = value;
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AAB3" /> struct.
    /// </summary>
    /// <param name="min">The minimum point in 3D space this box encloses.</param>
    /// <param name="max">The maximum point in 3D space this box encloses.</param>
    public AAB3(Vector3 min, Vector3 max)
    {
        _min = Vector3.ComponentMin(min, max);
        _max = Vector3.ComponentMax(min, max);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AAB3" /> struct.
    /// </summary>
    /// <param name="minX">The minimum X value to be enclosed.</param>
    /// <param name="minY">The minimum Y value to be enclosed.</param>
    /// <param name="minZ">The minimum Z value to be enclosed.</param>
    /// <param name="maxX">The maximum X value to be enclosed.</param>
    /// <param name="maxY">The maximum Y value to be enclosed.</param>
    /// <param name="maxZ">The maximum Z value to be enclosed.</param>
    public AAB3(
        float minX,
        float minY,
        float minZ,
        float maxX,
        float maxY,
        float maxZ
    )
        : this(new Vector3(minX, minY, minZ), new Vector3(maxX, maxY, maxZ))
    {
    }

    /// <summary>
    ///     Gets or sets a vector describing the size of the Box3 structure.
    /// </summary>
    [XmlIgnore]
    public Vector3 Size
    {
        get => Max - Min;
        set
        {
            var center = Center;
            _min = center - value * 0.5f;
            _max = center + value * 0.5f;
        }
    }

    /// <summary>
    ///     Gets or sets a vector describing half the size of the box.
    /// </summary>
    [XmlIgnore]
    public Vector3 HalfSize
    {
        get => Size / 2;
        set => Size = value * 2;
    }

    /// <summary>
    ///     Gets or sets a vector describing the center of the box.
    /// </summary>
    [XmlIgnore]
    public Vector3 Center
    {
        get => HalfSize + _min;
        set => Translate(value - Center);
    }

    /// <summary>
    ///     Returns whether the box contains the specified point (borders inclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure,
     Obsolete(
         "This function excludes borders even though it's documentation says otherwise. Use ContainsInclusive and ContainsExclusive for the desired behaviour."
     )]
    public bool Contains(Vector3 point) =>
        _min.X < point.X && point.X < _max.X && _min.Y < point.Y && point.Y < _max.Y && _min.Z < point.Z && point.Z < _max.Z;

    /// <summary>
    ///     Returns whether the box contains the specified point (borders inclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool ContainsInclusive(Vector3 point) =>
        _min.X <= point.X && point.X <= _max.X && _min.Y <= point.Y && point.Y <= _max.Y && _min.Z <= point.Z && point.Z <= _max.Z;

    /// <summary>
    ///     Returns whether the box contains the specified point (borders exclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool ContainsExclusive(Vector3 point) =>
        _min.X < point.X && point.X < _max.X && _min.Y < point.Y && point.Y < _max.Y && _min.Z < point.Z && point.Z < _max.Z;

    /// <summary>
    ///     Returns whether the box contains the specified point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <param name="boundaryInclusive">
    ///     Whether points on the box boundary should be recognised as contained as well.
    /// </param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool Contains(Vector3 point, bool boundaryInclusive) =>
        boundaryInclusive
            ? ContainsInclusive(point)
            : ContainsExclusive(point);

    /// <summary>
    ///     Returns whether the box contains the specified box (borders inclusive).
    /// </summary>
    /// <param name="other">The box to query.</param>
    /// <returns>Whether this box contains the other box.</returns>
    [Pure]
    public bool Contains(AAB3 other) =>
        _max.X >= other._min.X
        && _min.X <= other._max.X
        && _max.Y >= other._min.Y
        && _min.Y <= other._max.Y
        && _max.Z >= other._min.Z
        && _min.Z <= other._max.Z;

    /// <summary>
    ///     Returns the distance between the nearest edge and the specified point.
    /// </summary>
    /// <param name="point">The point to find distance for.</param>
    /// <returns>The distance between the specified point and the nearest edge.</returns>
    [Pure]
    public float DistanceToNearestEdge(Vector3 point)
    {
        var distX = new Vector3(
            System.Math.Max(0f, System.Math.Max(_min.X - point.X, point.X - _max.X)),
            System.Math.Max(0f, System.Math.Max(_min.Y - point.Y, point.Y - _max.Y)),
            System.Math.Max(0f, System.Math.Max(_min.Z - point.Z, point.Z - _max.Z))
        );
        return distX.Length;
    }

    /// <summary>
    ///     Translates this Box3 by the given amount.
    /// </summary>
    /// <param name="distance">The distance to translate the box.</param>
    public void Translate(Vector3 distance)
    {
        _min += distance;
        _max += distance;
    }

    /// <summary>
    ///     Returns a Box3 translated by the given amount.
    /// </summary>
    /// <param name="distance">The distance to translate the box.</param>
    /// <returns>The translated box.</returns>
    [Pure]
    public AAB3 Translated(Vector3 distance)
    {
        // create a local copy of this box
        var box = this;
        box.Translate(distance);
        return box;
    }

    /// <summary>
    ///     Scales this Box3 by the given amount.
    /// </summary>
    /// <param name="scale">The scale to scale the box.</param>
    /// <param name="anchor">The anchor to scale the box from.</param>
    public void Scale(Vector3 scale, Vector3 anchor)
    {
        _min = anchor + (_min - anchor) * scale;
        _max = anchor + (_max - anchor) * scale;
    }

    /// <summary>
    ///     Returns a Box3 scaled by a given amount from an anchor point.
    /// </summary>
    /// <param name="scale">The scale to scale the box.</param>
    /// <param name="anchor">The anchor to scale the box from.</param>
    /// <returns>The scaled box.</returns>
    [Pure]
    public AAB3 Scaled(Vector3 scale, Vector3 anchor)
    {
        // create a local copy of this box
        var box = this;
        box.Scale(scale, anchor);
        return box;
    }

    /// <summary>
    ///     Inflate this Box3 to encapsulate a given point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    public void Inflate(Vector3 point)
    {
        _min = Vector3.ComponentMin(_min, point);
        _max = Vector3.ComponentMax(_max, point);
    }

    /// <summary>
    ///     Inflate this Box3 to encapsulate a given point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>The inflated box.</returns>
    [Pure]
    public AAB3 Inflated(Vector3 point)
    {
        // create a local copy of this box
        var box = this;
        box.Inflate(point);
        return box;
    }

    /// <summary>
    ///     Equality comparator.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public static bool operator ==(AAB3 left, AAB3 right) => left.Equals(right);

    /// <summary>
    ///     Inequality comparator.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public static bool operator !=(AAB3 left, AAB3 right) => !(left == right);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is AAB3 aab3 && Equals(aab3);

    /// <inheritdoc />
    public bool Equals(AAB3 other) => _min.Equals(other._min) && _max.Equals(other._max);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(_min, _max);
}
