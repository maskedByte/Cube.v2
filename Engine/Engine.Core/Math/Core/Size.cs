using Engine.Math.Vector;

namespace Engine.Math.Core;

/// <summary>
/// A barebones implementation of the System.Drawing.Size structure
/// to support the use of Size in the Texture and FBO classes.
/// </summary>
public struct Size : IEquatable<Size>
{
    /// <summary>
    /// This width of the object that this Size is representing.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// This height of the object that this Size is representing.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Returns a Size with a width and height of 1.
    /// </summary>
    public static Size One
    {
        get { return new Size(1, 1); }
    }

    /// <summary>
    /// Returns a Size with a width and height of 0.
    /// </summary>
    public static Size Zero
    {
        get { return new Size(0, 0); }
    }

    public static Size Parse(string value, string separator = ",",
        StringSplitOptions stringSplitOptions = StringSplitOptions.None)
    {
        var values = value.Split(separator, stringSplitOptions);
        return new Size(
            int.Parse(values[0]),
            int.Parse(values[1]));
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Size"/> with given <paramref name="scalar"/>
    /// </summary>
    /// <param name="scalar">To set for <see cref="Width"/> and <see cref="Height"/></param>
    public Size(int scalar)
    {
        Width = scalar;
        Height = scalar;
    }

    /// <summary>
    /// Create a Size object with a specified width and height.
    /// </summary>
    /// <param name="width">The width to be represented by the Size object.</param>
    /// <param name="height">The height to be represented by the Size object.</param>
    public Size(int width, int height) : this()
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Create a Size object with a specified width and height.
    /// </summary>
    /// <param name="width">The width to be represented by the Size object.</param>
    /// <param name="height">The height to be represented by the Size object.</param>
    public Size(float width, float height) : this()
    {
        Width = (int)width;
        Height = (int)height;
    }

    public static implicit operator string(Size b)
    {
        return b.ToString();
    }

    public static implicit operator Vector3(Size b)
    {
        return new Vector3(b.Width, b.Height, 1.0f);
    }

    public static explicit operator Size(string b)
    {
        return Parse(b);
    }

    public static Size operator +(Size s1, Size s2)
    {
        return new Size(s1.Width + s2.Width, s1.Height + s2.Height);
    }

    public static Size operator +(Size s1, int factor)
    {
        return new Size(s1.Width + factor, s1.Height + factor);
    }

    public static Size operator -(Size s1, Size s2)
    {
        return new Size(s1.Width - s2.Width, s1.Height - s2.Height);
    }

    public static Size operator -(Size s1, int factor)
    {
        return new Size(s1.Width - factor, s1.Height - factor);
    }

    public static Size operator *(Size s1, Size s2)
    {
        return new Size(s1.Width * s2.Width, s1.Height * s2.Height);
    }

    public static Size operator *(Size s1, int factor)
    {
        return new Size(s1.Width * factor, s1.Height * factor);
    }

    public static Size operator /(Size s1, Size s2)
    {
        return new Size(s1.Width / s2.Width, s1.Height / s2.Height);
    }

    public static Size operator /(Size s1, int factor)
    {
        return new Size(s1.Width / factor, s1.Height / factor);
    }

    public static Size operator ^(Size s1, int factor)
    {
        return new Size(s1.Width ^ factor, s1.Height ^ factor);
    }

    public override string ToString()
    {
        return $"{Width}, {Height}";
    }

    public bool Equals(Size other)
    {
        return Width == other.Width && Height == other.Height;
    }

    public override bool Equals(object? obj)
    {
        return obj is Size other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }
}
