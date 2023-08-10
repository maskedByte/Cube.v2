// ReSharper disable CompareOfFloatsByEqualityOperator

using System.Runtime.InteropServices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Base;

[StructLayout(LayoutKind.Sequential)]
public struct Rect : IEquatable<Rect>
{
    private float _lenghtW;
    private float _lenghtH;

    private int _x;
    private int _y;
    private int _width;
    private int _height;

    private Vector3 _position;
    private Vector2 _size;

    public int X
    {
        get { return _x; }
        set
        {
            _x = value;
            CalculateLenght();
        }
    }

    public int Y
    {
        get { return _y; }
        set
        {
            _y = value;
            CalculateLenght();
        }
    }

    public int Width
    {
        get { return _width; }
        set
        {
            _width = value;
            CalculateLenght();
        }
    }

    public int Height
    {
        get { return _height; }
        set
        {
            _height = value;
            CalculateLenght();
        }
    }

    public Point UpperLeft
    {
        get { return new Point(_x, _y); }
    }

    public Point UpperRight
    {
        get { return new Point(_x + _width, _y); }
    }

    public Point BottomLeft
    {
        get { return new Point(_x, _y + _height); }
    }

    public Point BottomRight
    {
        get { return new Point(_x + _width, _y + _height); }
    }

    public static Rect Zero = new Rect(0, 0, 0, 0);

    public Rect()
    {
        _lenghtW = 0;
        _lenghtH = 0;
        _x = 0;
        _y = 0;
        _width = 0;
        _height = 0;
        _position = Vector3.Zero;
        _size = Vector2.Zero;
    }

    public Rect(int x, int y, int w, int h)
        : this()
    {
        _x = x;
        _y = y;
        _width = w;
        _height = h;

        CalculateLenght();
    }

    public Rect(int x, int y, Size size)
        : this()
    {
        _x = x;
        _y = y;
        _width = size.Width;
        _height = size.Height;

        CalculateLenght();
    }

    public Rect(Point position, Size size)
        : this()
    {
        _x = position.X;
        _y = position.Y;
        _width = size.Width;
        _height = size.Height;

        CalculateLenght();
    }

    public Rect(Vector2 position, Vector2 size)
        : this()
    {
        _x = (int)position.X;
        _y = (int)position.Y;
        _width = (int)size.X;
        _height = (int)size.Y;

        CalculateLenght();
    }

    public static Rect operator +(Rect a, Rect b)
    {
        return new Rect(
            a.X + b.X,
            a.Y + b.Y,
            a.Width + b.Width,
            a.Height + b.Height);
    }

    public static Rect operator -(Rect a, Rect b)
    {
        return new Rect(
            a.X * b.X,
            a.Y * b.Y,
            a.Width - b.Width,
            a.Height - b.Height);
    }

    public static bool operator ==(Rect left, Rect right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Rect left, Rect right)
    {
        return !(left == right);
    }

    public static implicit operator string(Rect b)
    {
        return b.ToString();
    }

    public static explicit operator Rect(string b)
    {
        return Parse(b);
    }

    public static Rect Parse(string value, string separator = ",",
        StringSplitOptions stringSplitOptions = StringSplitOptions.None)
    {
        var values = value.Split(separator, stringSplitOptions);

        return new Rect(
            int.Parse(values[0]),
            int.Parse(values[1]),
            int.Parse(values[2]),
            int.Parse(values[3])
        );
    }

    public static implicit operator Size(Rect value)
    {
        return new Size(value.Width, value.Height);
    }

    public static Rect Min(Rect a, Rect b)
    {
        return new Rect(
            a.X > b.X ? b.X : a.X,
            a.Y > b.Y ? b.Y : a.Y,
            a._width > b._width ? b._width : a._width,
            a._height > b._height ? b._height : a._height
        );
    }

    public static Rect Max(Rect a, Rect b)
    {
        return new Rect(
            a.X < b.X ? b.X : a.X,
            a.Y < b.Y ? b.Y : a.Y,
            a._width < b._width ? b._width : a._width,
            a._height < b._height ? b._height : a._height
        );
    }

    public bool IsWithin(Rect rect)
    {
        return X >= rect.X &&
               Y >= rect.Y &&
               X + Width <= rect.X + rect.Width &&
               Y + Height <= rect.Y + rect.Height;
    }

    public bool IsWithin(Vector2 point)
    {
        return point.X >= X &&
               point.Y >= Y &&
               point.X <= _lenghtW &&
               point.Y <= _lenghtH;
    }

    public bool IsWithin(float x, float y)
    {
        return x >= X &&
               y >= Y &&
               x <= _lenghtW &&
               y <= _lenghtH;
    }

    public bool IsWithin(Point point)
    {
        return point.X >= X &&
               point.Y >= Y &&
               point.X <= _lenghtW &&
               point.Y <= _lenghtH;
    }

    public Vector2 ToPosition()
    {
        return _position.Xy;
    }

    public Vector3 ToPosition3()
    {
        return _position;
    }

    public Vector2 ToSize()
    {
        return _size;
    }

    public bool Equals(Rect other)
    {
        return X == other.X &&
               Y == other.Y &&
               Width == other.Width &&
               Height == other.Height;
    }

    public override bool Equals(object? obj)
    {
        return obj is Rect other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_x, _y, _width, _height);
    }

    public override string ToString()
    {
        return $"{X}, {Y}, {Width}, {Height}";
    }

    private void CalculateLenght()
    {
        _lenghtW = _x + _width;
        _lenghtH = _y + _height;

        _position.X = _x;
        _position.Y = _y;
        _position.Z = 0;

        _size.X = _width;
        _size.Y = _height;
    }
}
