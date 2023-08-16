// ReSharper disable CompareOfFloatsByEqualityOperator

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Base;

/// <summary>
///     Representation of a color as R,G,B,A byte values ranging from 0-255
/// </summary>
[StructLayout(LayoutKind.Sequential), SuppressMessage("ReSharper", "InvalidXmlDocComment")]
public sealed class Color : IEquatable<Color>
{
    /// <summary>
    ///     Red value from 0 - 255
    /// </summary>
    public byte R { get; }

    /// <summary>
    ///     Green value from 0 - 255
    /// </summary>
    public byte G { get; }

    /// <summary>
    ///     Blue value from 0 - 255
    /// </summary>
    public byte B { get; }

    /// <summary>
    ///     Alpha value from 0 - 255
    /// </summary>
    public byte A { get; }

    public bool IsTranslucent => A < 255;

    public static Color Black => new(0, 0, 0, 255);

    public static Color White => new(255, 255, 255, 255);

    public static Color Transparent => new(255, 255, 255, 0);

    public static Color Red => new(255, 0, 0, 255);

    public static Color Green => new(0, 255, 0, 255);

    public static Color Blue => new(0, 0, 255, 255);

    /// <summary>
    ///     Create new instance of Color class by set a single value as RGB values
    /// </summary>
    public Color(int value)
        : this(value, value, value, 255)
    {
    }

    /// <summary>
    ///     Create new instance of Color class
    /// </summary>
    /// <param name="red">Red color value range 0 - 255</param>
    /// <param name="green">Green color value range 0 - 255</param>
    /// <param name="blue">Blue color value range 0 - 255</param>
    public Color(int red, int green, int blue)
        : this(red, green, blue, 255)
    {
    }

    /// <summary>
    ///     Create new instance of Color class
    /// </summary>
    /// <param name="red">Red color value range 0 - 255</param>
    /// <param name="green">Green color value range 0 - 255</param>
    /// <param name="blue">Blue color value range 0 - 255</param>
    /// <param name="alpha">Alpha color value range 0 - 255</param>
    public Color(
        int red,
        int green,
        int blue,
        int alpha
    )
    {
        R = (byte)Mathf.Clamp(red, 0, 255);
        G = (byte)Mathf.Clamp(green, 0, 255);
        B = (byte)Mathf.Clamp(blue, 0, 255);
        A = (byte)Mathf.Clamp(alpha, 0, 255);
    }

    /// <summary>
    ///     Create new instance of Color class
    /// </summary>
    /// <param name="red">Red color value range 0.0 - 1.0</param>
    /// <param name="green">Green color value range 0.0 - 1.0</param>
    /// <param name="blue">Blue color value range 0.0 - 1.0</param>
    /// <param name="alpha">Alpha color value range 0.0 - 1.0</param>
    public Color(
        float red,
        float green,
        float blue,
        float alpha
    )
    {
        R = (byte)Mathf.Clamp(255 * red, 0f, 1f);
        G = (byte)Mathf.Clamp(255 * green, 0f, 1f);
        B = (byte)Mathf.Clamp(255 * blue, 0f, 1f);
        A = (byte)Mathf.Clamp(255 * alpha, 0f, 1f);
    }

    /// <summary>
    ///     Check if color is equal to <paramref name="other" />
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Color? other)
    {
        if (other != null)
        {
            return false;
        }

        return
            R == other!.R && G == other.G && B == other.B && A == other.A;
    }

    /// <summary>
    ///     Implicit convert System.Drawing.Color into <see cref="Color" />
    /// </summary>
    public static implicit operator Color(System.Drawing.Color color) => new(color.R, color.G, color.B, color.A);

    public static Color operator +(Color color1, Color color2) =>
        new(
            color1.R + color2.R,
            color1.G + color2.G,
            color1.B + color2.B,
            color1.A + color2.A
        );

    public static Color operator -(Color color1, Color color2) =>
        new(
            color1.R - color2.R,
            color1.G - color2.G,
            color1.B - color2.B,
            color1.A - color2.A
        );

    public static Color operator *(Color color1, Color color2) =>
        new(
            color1.R * color2.R,
            color1.G * color2.G,
            color1.B * color2.B,
            color1.A * color2.A
        );

    /// <summary>
    ///     Convert <see cref="System.Drawing.Color" /> into <see cref="Color" />
    /// </summary>
    /// <param name="color"></param>
    /// <returns>New created <see cref="Color" /></returns>
    public static Color FromDrawingColor(System.Drawing.Color color) => new(color.R, color.G, color.B, color.A);

    /// <summary>
    ///     Convert <see cref="System.Drawing.Color" /> into <see cref="Color" />
    /// </summary>
    /// <param name="color"></param>
    /// <param name="alpha"></param>
    /// <returns>New created <see cref="Color" /></returns>
    public static Color FromDrawingColor(System.Drawing.Color color, byte alpha) => new(color.R, color.G, color.B, alpha);

    /// <summary>
    ///     Return a vector4 for this color where color values converted from RGBA into Float
    /// </summary>
    /// <returns>New <see cref="Vector3" /> containing the color value</returns>
    public Vector3 ToVector3() => new(R / 255f, G / 255f, B / 255f);

    /// <summary>
    ///     Return a <see cref="Vector4" /> for this color where color values converted from RGBA into Float
    /// </summary>
    /// <returns>New <see cref="Vector4" /> containing the color value</returns>
    public Vector4 ToVector4() => new(R / 255f, G / 255f, B / 255f, A / 255f);

    /// <summary>
    ///     Convert RGB color to Hsl color
    /// </summary>
    /// <returns></returns>
    public HslColor ToHsl() => this;

    /// <summary>
    ///     Convert <see cref="Vector3" /> into <see cref="Color" />
    /// </summary>
    /// <param name="color"><see cref="Vector3" /> vector to convert to <see cref="Color" />, value range from 0-1 </param>
    /// <returns></returns>
    public static Color FromVector(Vector3 color) => new(color.X, color.Y, color.Z, 1.0f);

    /// <summary>
    ///     Convert <see cref="Vector4" /> into <see cref="Color" />
    /// </summary>
    /// <param name="color"><see cref="Vector4" /> vector to convert to <see cref="Color" />, value range from 0-1 </param>
    /// <returns></returns>
    public static Color FromVector(Vector4 color) => new(color.X, color.Y, color.Z, color.W);

    /// <summary>
    ///     Returns the Lightness
    /// </summary>
    public float GetBrightness()
    {
        var r = R / 255.0f;
        var g = G / 255.0f;
        var b = B / 255.0f;

        var max = r;
        var min = r;

        if (g > max)
        {
            max = g;
        }

        if (b > max)
        {
            max = b;
        }

        if (g < min)
        {
            min = g;
        }

        if (b < min)
        {
            min = b;
        }

        return (max + min) / 2;
    }

    /// <summary>
    ///     Returns the hue value, in degrees
    /// </summary>
    public float GetHue()
    {
        if (R == G && G == B)
        {
            return 0; // 0 makes as good an UNDEFINED value as any
        }

        var r = R / 255.0f;
        var g = G / 255.0f;
        var b = B / 255.0f;

        var hue = 0.0f;

        var max = r;
        var min = r;

        if (g > max)
        {
            max = g;
        }

        if (b > max)
        {
            max = b;
        }

        if (g < min)
        {
            min = g;
        }

        if (b < min)
        {
            min = b;
        }

        var delta = max - min;

        if (r == max)
        {
            hue = (g - b) / delta;
        }
        else if (g == max)
        {
            hue = 2 + (b - r) / delta;
        }
        else if (b == max)
        {
            hue = 4 + (r - g) / delta;
        }

        hue *= 60;

        if (hue < 0.0f)
        {
            hue += 360.0f;
        }

        return hue;
    }

    /// <summary>
    ///     Returns the Saturation value
    /// </summary>
    public float GetSaturation()
    {
        var r = R / 255.0f;
        var g = G / 255.0f;
        var b = B / 255.0f;

        float s = 0;

        var max = r;
        var min = r;

        if (g > max)
        {
            max = g;
        }

        if (b > max)
        {
            max = b;
        }

        if (g < min)
        {
            min = g;
        }

        if (b < min)
        {
            min = b;
        }

        // if max == min, then there is no color and
        // the saturation is zero.
        //
        if (max == min)
        {
            return s;
        }

        var l = (max + min) / 2;

        if (l <= .5)
        {
            s = (max - min) / (max + min);
        }
        else
        {
            s = (max - min) / (2 - max - min);
        }

        return s;
    }

    /// <summary>
    ///     Interpolates the current color with another color by a given factor.
    /// </summary>
    /// <param name="color">The color to interpolate with</param>
    /// <param name="factor">The interpolation factor, a value between 0 and 1.</param>
    /// <remarks>
    ///     A factor of 0 will result in the current color, a factor of 1 will result in the provided color,
    ///     and a factor of 0.5 will result in a color halfway between the two.
    /// </remarks>
    /// <returns>The interpolated color</returns>
    public Color Interpolate(Color color, float factor)
    {
        var red = R + (color.R - R) * factor;
        var green = G + (color.G - G) * factor;
        var blue = B + (color.B - B) * factor;
        var alpha = A + (color.A - A) * factor;

        return new Color(red, green, blue, alpha);
    }

    public override string ToString() => $"{R} {G} {B} {A}";

    /// <summary>
    ///     Parse a string to <see cref="Color" />, format can be #ff44aa or <255,255,255,255> or 255,255,255,255
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static Color Parse(string text)
    {
        // Check if hex
        if (text.Trim().StartsWith('#'))
        {
            var colorHex = text.ToUpper().TrimStart('#');
            var r = int.Parse(colorHex[..2], NumberStyles.HexNumber);
            var g = int.Parse(colorHex[2..4], NumberStyles.HexNumber);
            var b = int.Parse(colorHex[4..6], NumberStyles.HexNumber);
            var a = colorHex.Length > 6
                ? int.Parse(colorHex[6..8], NumberStyles.HexNumber)
                : 255;
            return new Color(r, g, b, a);
        }

        var split = text.Trim('<', '>').Split(',');
        if (split.Length != 4)
        {
            return Black;
        }

        return new Color(
            byte.Parse(split[0]),
            byte.Parse(split[1]),
            byte.Parse(split[2]),
            byte.Parse(split[3])
        );
    }

    public override bool Equals(object? obj) => Equals(obj as Color);

    public override int GetHashCode() => HashCode.Combine(R, G, B, A);
}
