using System.Runtime.InteropServices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Base;

/// <summary>
///     A barebones implementation of the System.Drawing.Size structure
///     to support the use of Size in the Texture and FBO classes.
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public struct Size : IEquatable<Size>
{
    /// <summary>
    ///     This width of the object that this Size is representing.
    /// </summary>
    public int Width { get; }

    /// <summary>
    ///     This height of the object that this Size is representing.
    /// </summary>
    public int Height { get; }

    /// <summary>
    ///     Returns a Size with a width and height of 1.
    /// </summary>
    public static Size One => new(1, 1);

    /// <summary>
    ///     Returns a Size with a width and height of 0.
    /// </summary>
    public static Size Zero => new(0, 0);

    public static Size Parse(
        string value,
        string separator = ",",
        StringSplitOptions stringSplitOptions = StringSplitOptions.None
    )
    {
        var values = value.Split(separator, stringSplitOptions);
        return new Size(
            int.Parse(values[0]),
            int.Parse(values[1])
        );
    }

    /// <summary>
    ///     Initialize a new instance of <see cref="Size" /> with given <paramref name="scalar" />
    /// </summary>
    /// <param name="scalar">To set for <see cref="Width" /> and <see cref="Height" /></param>
    public Size(int scalar)
    {
        Width = scalar;
        Height = scalar;
    }

    /// <summary>
    ///     Create a Size object with a specified width and height.
    /// </summary>
    /// <param name="width">The width to be represented by the Size object.</param>
    /// <param name="height">The height to be represented by the Size object.</param>
    public Size(int width, int height)
        : this()
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Create a Size object with a specified width and height.
    /// </summary>
    /// <param name="width">The width to be represented by the Size object.</param>
    /// <param name="height">The height to be represented by the Size object.</param>
    public Size(float width, float height)
        : this()
    {
        Width = (int)width;
        Height = (int)height;
    }

    public static implicit operator string(Size b) => b.ToString();

    public static implicit operator Vector3(Size b) => new(b.Width, b.Height, 1.0f);

    public static explicit operator Size(string b) => Parse(b);

    public static Size operator +(Size s1, Size s2) => new(s1.Width + s2.Width, s1.Height + s2.Height);

    public static Size operator +(Size s1, int factor) => new(s1.Width + factor, s1.Height + factor);

    public static Size operator -(Size s1, Size s2) => new(s1.Width - s2.Width, s1.Height - s2.Height);

    public static Size operator -(Size s1, int factor) => new(s1.Width - factor, s1.Height - factor);

    public static Size operator *(Size s1, Size s2) => new(s1.Width * s2.Width, s1.Height * s2.Height);

    public static Size operator *(Size s1, int factor) => new(s1.Width * factor, s1.Height * factor);

    public static Size operator /(Size s1, Size s2) => new(s1.Width / s2.Width, s1.Height / s2.Height);

    public static Size operator /(Size s1, int factor) => new(s1.Width / factor, s1.Height / factor);

    public static Size operator ^(Size s1, int factor) => new(s1.Width ^ factor, s1.Height ^ factor);

    public override string ToString() => $"{Width}, {Height}";

    public bool Equals(Size other) => Width == other.Width && Height == other.Height;

    public override bool Equals(object? obj) => obj is Size other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Width, Height);
}
