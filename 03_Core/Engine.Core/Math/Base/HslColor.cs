using System.Runtime.InteropServices;

namespace Engine.Core.Math.Base;

/// <summary>
///     Represents a <see cref="Color" /> as HSL value
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed class HslColor
{
    private const double Scale = 240.0;
    private double _hue = 1.0;
    private double _luminosity = 1.0;
    private double _saturation = 1.0;

    public double Hue
    {
        get => _hue * Scale;
        init => _hue = Mathf.Clamp01(value / Scale);
    }

    public double Saturation
    {
        get => _saturation * Scale;
        init => _saturation = Mathf.Clamp01(value / Scale);
    }

    public double Luminosity
    {
        get => _luminosity * Scale;
        init => _luminosity = Mathf.Clamp01(value / Scale);
    }

    public HslColor()
    {
    }

    public HslColor(Color color)
    {
        SetRgb(color.R, color.G, color.B);
    }

    public HslColor(int red, int green, int blue)
    {
        SetRgb(red, green, blue);
    }

    public HslColor(double hue, double saturation, double luminosity)
    {
        Hue = Mathf.Clamp01(hue);
        Saturation = Mathf.Clamp01(saturation);
        Luminosity = Mathf.Clamp01(luminosity);
    }

    public static implicit operator Color(HslColor hslColor)
    {
        double r;
        double g;
        double b;

        if (hslColor._luminosity == 0)
        {
            return Color.Black;
        }

        if (hslColor._saturation == 0)
        {
            r = g = b = hslColor._luminosity;
        }
        else
        {
            var temp2 = GetTemp2(hslColor);
            var temp1 = 2.0 * hslColor._luminosity - temp2;

            r = GetColorComponent(temp1, temp2, hslColor._hue + 1.0 / 3.0);
            g = GetColorComponent(temp1, temp2, hslColor._hue);
            b = GetColorComponent(temp1, temp2, hslColor._hue - 1.0 / 3.0);
        }

        return new Color((int)(255 * r), (int)(255 * g), (int)(255 * b));
    }

    public static implicit operator HslColor(Color color) =>
        new()
        {
            _hue = color.GetHue() / 360.0, // we store hue as 0-1 as opposed to 0-360
            _luminosity = color.GetBrightness(),
            _saturation = color.GetSaturation()
        };

    public static HslColor operator /(HslColor color1, HslColor color2) =>
        new(
            color1.Hue / color2.Hue,
            color1.Saturation / color2.Saturation,
            color1.Luminosity / color2.Luminosity
        );

    public static HslColor operator *(HslColor color1, HslColor color2) =>
        new(
            color1.Hue * color2.Hue,
            color1.Saturation * color2.Saturation,
            color1.Luminosity * color2.Luminosity
        );

    public override string ToString() => $"H: {Hue:#0.##} S: {Saturation:#0.##} L: {Luminosity:#0.##}";

    public string ToRgbString()
    {
        var color = (Color)this;
        return $"R: {color.R:#0.##} G: {color.G:#0.##} B: {color.B:#0.##}";
    }

    public void SetRgb(int red, int green, int blue)
    {
        var hslColor = (HslColor)new Color(red, green, blue);
        _hue = hslColor._hue;
        _saturation = hslColor._saturation;
        _luminosity = hslColor._luminosity;
    }

    private static double GetColorComponent(double temp1, double temp2, double temp3)
    {
        temp3 = MoveIntoRange(temp3);
        return temp3 switch
        {
            < 1.0 / 6.0 => temp1 + (temp2 - temp1) * 6.0 * temp3,
            < 0.5       => temp2,
            < 2.0 / 3.0 => temp1 + (temp2 - temp1) * (2.0 / 3.0 - temp3) * 6.0,
            _           => temp1
        };
    }

    private static double MoveIntoRange(double temp3)
    {
        switch (temp3)
        {
            case < 0.0:
                temp3 += 1.0;
                break;
            case > 1.0:
                temp3 -= 1.0;
                break;
        }

        return temp3;
    }

    private static double GetTemp2(HslColor hslColor)
    {
        double temp2;
        if (hslColor._luminosity < 0.5)
        {
            temp2 = hslColor._luminosity * (1.0 + hslColor._saturation);
        }
        else
        {
            temp2 = hslColor._luminosity + hslColor._saturation - hslColor._luminosity * hslColor._saturation;
        }

        return temp2;
    }
}
