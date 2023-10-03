using System.Runtime.InteropServices;

namespace Engine.Core.Math.Base;

[Serializable, StructLayout(LayoutKind.Sequential)]
public struct Point : IEquatable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(float x, float y)
    {
        X = (int)x;
        Y = (int)y;
    }

    public static Point Zero => new(0, 0);

    public static Point One => new(1, 1);

    public static Point Parse(
        string value,
        string separator = ",",
        StringSplitOptions stringSplitOptions = StringSplitOptions.None
    )
    {
        var values = value.Split(separator, stringSplitOptions);
        return new Point(
            int.Parse(values[0]),
            int.Parse(values[1])
        );
    }

    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);

    public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);

    public static bool operator ==(Point left, Point right) => left.Equals(right);

    public static bool operator !=(Point left, Point right) => !(left == right);

    public static implicit operator string(Point b) => b.ToString();

    public static explicit operator Point(string b) => Parse(b);

    /// <summary>
    ///     Returns the minimum point between two given points.
    /// </summary>
    /// <param name="a">The first point to compare.</param>
    /// <param name="b">The second point to compare.</param>
    /// <returns>A new point that represents the minimum values of the X and Y coordinates of the two given points.</returns>
    public static Point Min(Point a, Point b) =>
        new(
            a.X > b.X
                ? b.X
                : a.X,
            a.Y > b.Y
                ? b.Y
                : a.Y
        );

    /// <summary>
    ///     Returns the maximum point between two given points.
    /// </summary>
    /// <param name="a">The first point to compare.</param>
    /// <param name="b">The second point to compare.</param>
    /// <returns>A new point that represents the maximum values of the X and Y coordinates of the two given points.</returns>
    public static Point Max(Point a, Point b) =>
        new(
            a.X < b.X
                ? b.X
                : a.X,
            a.Y < b.Y
                ? b.Y
                : a.Y
        );

    /// <summary>
    ///     Determines if a point is within a specified rectangle.
    /// </summary>
    /// <param name="rect">The rectangle to check against.</param>
    /// <returns>True if the point is within the rectangle, false otherwise.</returns>
    public bool IsWithin(Rect rect) => !(X < rect.X || Y < rect.Y || X > rect.X + rect.Width || Y > rect.Y + rect.Height);

    public override string ToString() => X + "," + Y;

    public bool Equals(Point other) => X == other.X && Y == other.Y;

    public override bool Equals(object? obj) => obj is Point other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);
}
