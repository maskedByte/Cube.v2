using System.Runtime.InteropServices;

namespace Engine.Math.Core;

[StructLayout(LayoutKind.Sequential)]
public struct Viewport : IEquatable<Viewport>
{
    /// <summary>
    /// X position of the Viewport
    /// </summary>
    public float X;

    /// <summary>
    /// Y position of the Viewport
    /// </summary>
    public float Y;

    /// <summary>
    /// Width of the Viewport
    /// </summary>
    public float Width;

    /// <summary>
    /// Height of the Viewport
    /// </summary>
    public float Height;

    /// <summary>
    /// Access properties by index
    /// </summary>
    /// <param name="index">index of the parameter</param>
    /// <returns></returns>
    public float this[int index]
    {
        get
        {
            return index switch
            {
                0 => X,
                1 => Y,
                2 => Width,
                3 => Height,
                _ => throw new Exception("Index out of range.")
            };
        }
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

    public bool Equals(Viewport other)
    {
        return X.Equals(other.X)
               && Y.Equals(other.Y)
               && Width.Equals(other.Width)
               && Height.Equals(other.Height);
    }

    public override bool Equals(object? obj)
    {
        return obj is Viewport other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Width, Height);
    }
}
