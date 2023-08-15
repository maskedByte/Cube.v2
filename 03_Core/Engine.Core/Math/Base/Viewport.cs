using System.Runtime.InteropServices;

namespace Engine.Core.Math.Base;

[StructLayout(LayoutKind.Sequential)]
public struct Viewport : IEquatable<Viewport>
{
    /// <summary>
    ///     X position of the Viewport
    /// </summary>
    public int X;

    /// <summary>
    ///     Y position of the Viewport
    /// </summary>
    public int Y;

    /// <summary>
    ///     Width of the Viewport
    /// </summary>
    public int Width;

    /// <summary>
    ///     Height of the Viewport
    /// </summary>
    public int Height;

    /// <summary>
    ///     Access properties by index
    /// </summary>
    /// <param name="index">index of the parameter</param>
    /// <returns></returns>
    public int this[int index]
    {
        get =>
            index switch
            {
                0 => X,
                1 => Y,
                2 => Width,
                3 => Height,
                _ => throw new Exception("Index out of range.")
            };
        set
        {
            switch (index)
            {
                case 0:
                    X = value;
                    break;
                case 1:
                    Y = value;
                    break;
                case 2:
                    Width = value;
                    break;
                case 3:
                    Height = value;
                    break;
                default:
                    throw new Exception("Index out of range.");
            }
        }
    }

    public Viewport(float x, float y, float width, float height)
    {
        X = (int)x;
        Y = (int)y;
        Width = (int)width;
        Height = (int)height;
    }

    public Viewport(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public bool Equals(Viewport other) =>
        X.Equals(other.X)
        && Y.Equals(other.Y)
        && Width.Equals(other.Width)
        && Height.Equals(other.Height);

    public override bool Equals(object? obj) => obj is Viewport other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);
}
