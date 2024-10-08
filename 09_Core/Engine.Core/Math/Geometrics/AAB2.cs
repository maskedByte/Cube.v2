﻿using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Geometrics;

/// <summary>
///     Defines an axis-aligned 2d box (rectangle).
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public struct AAB2 : IEquatable<AAB2>
{
    private Vector2 _min;

    /// <summary>
    ///     Gets or sets the minimum boundary of the structure.
    /// </summary>
    public Vector2 Min
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

            _min = value;
        }
    }

    private Vector2 _max;

    /// <summary>
    ///     Gets or sets the maximum boundary of the structure.
    /// </summary>
    public Vector2 Max
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

            _max = value;
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AAB2" /> struct.
    /// </summary>
    /// <param name="min">The minimum point on the XY plane this box encloses.</param>
    /// <param name="max">The maximum point on the XY plane this box encloses.</param>
    public AAB2(Vector2 min, Vector2 max)
    {
        _min = Vector2.ComponentMin(min, max);
        _max = Vector2.ComponentMax(min, max);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AAB2" /> struct.
    /// </summary>
    /// <param name="minX">The minimum X value to be enclosed.</param>
    /// <param name="minY">The minimum Y value to be enclosed.</param>
    /// <param name="maxX">The maximum X value to be enclosed.</param>
    /// <param name="maxY">The maximum Y value to be enclosed.</param>
    public AAB2(
        float minX,
        float minY,
        float maxX,
        float maxY
    )
        : this(new Vector2(minX, minY), new Vector2(maxX, maxY))
    {
    }

    /// <summary>
    ///     Gets or sets a vector describing the size of the AAB2 structure.
    /// </summary>
    [XmlIgnore]
    public Vector2 Size
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
    public Vector2 HalfSize
    {
        get => Size / 2;
        set => Size = value * 2;
    }

    /// <summary>
    ///     Gets or sets a vector describing the center of the box.
    /// </summary>
    [XmlIgnore]
    public Vector2 Center
    {
        get => HalfSize + _min;
        set => Translate(value - Center);
    }

    /// <summary>
    ///     Returns whether the box contains the specified point (borders exclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure,
     Obsolete(
         "This function used to exclude borders, but to follow changes from the other Box structs it's deprecated. Use ContainsInclusive and ContainsExclusive for the desired behaviour."
     )]
    public bool Contains(Vector2 point) => _min.X < point.X && point.X < _max.X && _min.Y < point.Y && point.Y < _max.Y;

    /// <summary>
    ///     Returns whether the box contains the specified point (borders inclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool ContainsInclusive(Vector2 point) => _min.X <= point.X && point.X <= _max.X && _min.Y <= point.Y && point.Y <= _max.Y;

    /// <summary>
    ///     Returns whether the box contains the specified point (borders exclusive).
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool ContainsExclusive(Vector2 point) => _min.X < point.X && point.X < _max.X && _min.Y < point.Y && point.Y < _max.Y;

    /// <summary>
    ///     Returns whether the box contains the specified point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <param name="boundaryInclusive">
    ///     Whether points on the box boundary should be recognised as contained as well.
    /// </param>
    /// <returns>Whether this box contains the point.</returns>
    [Pure]
    public bool Contains(Vector2 point, bool boundaryInclusive) =>
        boundaryInclusive
            ? ContainsInclusive(point)
            : ContainsExclusive(point);

    /// <summary>
    ///     Returns whether the box contains the specified box (borders inclusive).
    /// </summary>
    /// <param name="other">The box to query.</param>
    /// <returns>Whether this box contains the other box.</returns>
    [Pure]
    public bool Contains(AAB2 other) =>
        _max.X >= other._min.X && _min.X <= other._max.X && _max.Y >= other._min.Y && _min.Y <= other._max.Y;

    /// <summary>
    ///     Returns the distance between the nearest edge and the specified point.
    /// </summary>
    /// <param name="point">The point to find distance for.</param>
    /// <returns>The distance between the specified point and the nearest edge.</returns>
    [Pure]
    public float DistanceToNearestEdge(Vector2 point)
    {
        var distX = new Vector2(
            System.Math.Max(0f, System.Math.Max(_min.X - point.X, point.X - _max.X)),
            System.Math.Max(0f, System.Math.Max(_min.Y - point.Y, point.Y - _max.Y))
        );
        return distX.Length;
    }

    /// <summary>
    ///     Translates this AAB2 by the given amount.
    /// </summary>
    /// <param name="distance">The distance to translate the box.</param>
    public void Translate(Vector2 distance)
    {
        _min += distance;
        _max += distance;
    }

    /// <summary>
    ///     Returns a AAB2 translated by the given amount.
    /// </summary>
    /// <param name="distance">The distance to translate the box.</param>
    /// <returns>The translated box.</returns>
    [Pure]
    public AAB2 Translated(Vector2 distance)
    {
        // create a local copy of this box
        var box = this;
        box.Translate(distance);
        return box;
    }

    /// <summary>
    ///     Scales this AAB2 by the given amount.
    /// </summary>
    /// <param name="scale">The scale to scale the box.</param>
    /// <param name="anchor">The anchor to scale the box from.</param>
    public void Scale(Vector2 scale, Vector2 anchor)
    {
        _min = anchor + (_min - anchor) * scale;
        _max = anchor + (_max - anchor) * scale;
    }

    /// <summary>
    ///     Returns a AAB2 scaled by a given amount from an anchor point.
    /// </summary>
    /// <param name="scale">The scale to scale the box.</param>
    /// <param name="anchor">The anchor to scale the box from.</param>
    /// <returns>The scaled box.</returns>
    [Pure]
    public AAB2 Scaled(Vector2 scale, Vector2 anchor)
    {
        // create a local copy of this box
        var box = this;
        box.Scale(scale, anchor);
        return box;
    }

    /// <summary>
    ///     Inflate this AAB2 to encapsulate a given point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    public void Inflate(Vector2 point)
    {
        _min = Vector2.ComponentMin(_min, point);
        _max = Vector2.ComponentMax(_max, point);
    }

    /// <summary>
    ///     Inflate this AAB2 to encapsulate a given point.
    /// </summary>
    /// <param name="point">The point to query.</param>
    /// <returns>The inflated box.</returns>
    [Pure]
    public AAB2 Inflated(Vector2 point)
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
    public static bool operator ==(AAB2 left, AAB2 right) => left.Equals(right);

    /// <summary>
    ///     Inequality comparator.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public static bool operator !=(AAB2 left, AAB2 right) => !(left == right);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is AAB2 aab2 && Equals(aab2);

    /// <inheritdoc />
    public bool Equals(AAB2 other) => _min.Equals(other._min) && _max.Equals(other._max);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(_min, _max);
}
