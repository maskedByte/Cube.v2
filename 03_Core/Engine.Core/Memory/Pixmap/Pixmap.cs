using Engine.Core.Math;
using Engine.Core.Math.Base;

namespace Engine.Core.Memory.Pixmap;

/// <summary>
///     Pixmap is the base class for all pixel based data structures in the engine.
/// </summary>
public sealed class Pixmap : IPixmap
{
    private Rect _cacheRect = Rect.Zero;
    private byte[] _dataResult = Array.Empty<byte>();
    private bool _modified;

    /// <summary>
    ///     Pixel data for the pixmap, data format is always RGBA
    /// </summary>
    public Color[,] Data { get; private set; }

    /// <summary>
    ///     Width and Height of a pixmap
    /// </summary>
    public Size Size { get; }

    /// <summary>
    ///     Create a new <see cref="Pixmap" />
    /// </summary>
    /// <param name="size">Set the size for the Pixmap</param>
    public Pixmap(Size size)
        : this(size, new Color[size.Width, size.Height])
    {
        _modified = true;
    }

    /// <summary>
    ///     Create a new <see cref="Pixmap" />
    /// </summary>
    /// <param name="size">Set the size for the Pixmap</param>
    /// <param name="data">Set data for the pixmap</param>
    public Pixmap(Size size, Color[,] data)
    {
        Size = size;
        Data = data;
        _modified = true;
        Clear(Color.Transparent);
    }

    /// <summary>
    ///     Create a new <see cref="Pixmap" /> from given data and given <see cref="size" />
    /// </summary>
    /// <param name="size"><see cref="Size" /> of the image</param>
    /// <param name="data">Byte array containing RGB/A values eg. (255,125,55,255;....)</param>
    /// <param name="format"><see cref="PixelFormat" /> describe the pixel format for the given pixel structure</param>
    public Pixmap(Size size, IReadOnlyList<byte> data, PixelFormat format)
    {
        Size = size;
        Data = null!;
        _modified = true;

        ReadRaw(data, format);
    }

    /// <summary>
    ///     Create a new <see cref="Pixmap" /> with the given <see cref="Size" /> and <see cref="Color" />
    /// </summary>
    /// <param name="color"><see cref="Color" /> to fill the new pixmap.</param>
    /// <param name="size"><see cref="Size" /> set the width and the height of the new pixmap.</param>
    public Pixmap(Color color, Size size)
    {
        Size = size;
        Data = new Color[Size.Width, Size.Height];
        _modified = true;

        for (var y = 0; y < Size.Height; y++)
        {
            for (var x = 0; x < Size.Width; x++)
            {
                Data[x, y] = color;
            }
        }
    }

    /// <inheritdoc />
    public byte[] GetRaw()
    {
        if (_dataResult.Length == 0)
        {
            _dataResult = new byte[Size.Width * Size.Height * 4];
        }

        if (_modified)
        {
            var pointer = 0;

            for (var y = 0; y < Size.Height; y++)
            {
                for (var x = 0; x < Size.Width; x++)
                {
                    var pix = Data[x, y];
                    _dataResult[pointer] = pix.R;
                    _dataResult[pointer + 1] = pix.G;
                    _dataResult[pointer + 2] = pix.B;
                    _dataResult[pointer + 3] = pix.A;

                    pointer += 4;
                }
            }

            _modified = false;
        }

        return _dataResult;
    }

    /// <inheritdoc />
    public void SetRaw(byte[] data) => ReadRaw(data, PixelFormat.Rgba);

    /// <inheritdoc />
    public Pixmap GetArea(Rect area)
    {
        var newPix = new Pixmap(new Size(area.Width, area.Height), new Color[area.Width, area.Height]);

        for (var y = 0; y < area.Height; ++y)
        {
            for (var x = 0; x < area.Width; ++x)
            {
                newPix.Data[x, y] = Data[area.X + x, area.Y + y];
            }
        }

        return newPix;
    }

    /// <inheritdoc />
    public void Clear(Color color) => DrawRect(new Rect(0, 0, Size), color, true);

    /// <inheritdoc />
    public void DrawPixmap(Pixmap source, BlendMode mode, int x = 0, int y = 0)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (x > Size.Width || y > Size.Height)
        {
            return;
        }

        if (x + source.Size.Width <= 0 || y + source.Size.Height <= 0)
        {
            return;
        }

        // Calculate positions
        var endXCalculated = source.Size.Width - Mathf.Abs(Size.Width - (x + source.Size.Width));
        var endYCalculated = source.Size.Height - Mathf.Abs(Size.Height - (y + source.Size.Height));
        var endX = x >= 0 && endXCalculated < source.Size.Width
            ? source.Size.Width
            : endXCalculated;
        var endY = y >= 0 && endYCalculated < source.Size.Height
            ? source.Size.Height
            : endYCalculated;

        var startX = 0;
        var startY = 0;
        if (x <= 0)
        {
            startX = Mathf.Abs(x);
            endX = source.Size.Width;
        }

        if (y <= 0)
        {
            startY = Mathf.Abs(y);
            endY = source.Size.Height;
        }

        // Plot into target
        for (var py = startY; py < endY; py++)
        {
            for (var px = startX; px < endX; px++)
            {
                Plot(x + px, y + py, source.Data[px, py], mode);
            }
        }
    }

    /// <inheritdoc />
    public void Plot(int x, int y, Color color, BlendMode mode)
    {
        if (x < 0 || x > Size.Width - 1)
        {
            return;
        }

        if (y < 0 || y > Size.Height - 1)
        {
            return;
        }

        var resultColor = mode switch
        {
            BlendMode.Addition       => Data[x, y] + color,
            BlendMode.Multiplication => Data[x, y] * color,
            BlendMode.Replace        => color,
            BlendMode.Subtract       => Data[x, y] - color,
            _                        => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };

        PlotInternal(x, y, resultColor);
    }

    /// <inheritdoc />
    public void DrawLine(Point start, Point end, Color color) => DrawLine(start.X, start.Y, end.X, end.Y, color);

    /// <inheritdoc />
    /// <remarks>Uses Bresenham's line algorithm</remarks>
    public void DrawLine(int startX, int startY, int endX, int endY, Color color)
    {
        startX = Mathf.Clamp(startX, 0, Size.Width - 1);
        startY = Mathf.Clamp(startY, 0, Size.Height - 1);
        endX = Mathf.Clamp(endX, 0, Size.Width - 1);
        endY = Mathf.Clamp(endY, 0, Size.Height - 1);

        var dx = Mathf.Abs(endX - startX);
        var sx = startX < endX
            ? 1
            : -1;
        var dy = -Mathf.Abs(endY - startY);
        var sy = startY < endY
            ? 1
            : -1;
        var error = dx + dy;

        while (true)
        {
            PlotInternal(startX, startY, color);
            if (startX == endX && startY == endY)
            {
                break;
            }

            var e2 = 2 * error;
            if (e2 >= dy)
            {
                if (startX == endX)
                {
                    break;
                }

                error += +dy;
                startX += +sx;
            }

            if (e2 > dx)
            {
                continue;
            }

            if (startY == endY)
            {
                break;
            }

            error += dx;
            startY += sy;
        }
    }

    /// <inheritdoc />
    public void DrawRect(int x, int y, int width, int height, Color color, bool fill)
    {
        _cacheRect.X = x;
        _cacheRect.Y = y;
        _cacheRect.Width = width;
        _cacheRect.Height = height;

        DrawRect(_cacheRect, color, fill);
    }

    /// <inheritdoc />
    public void DrawRect(Rect shape, Color color, bool fill)
    {
        var startX = shape.X < 0
            ? 0
            : shape.X;
        var startY = shape.Y < 0
            ? 0
            : shape.Y;
        var width = startX + shape.Width > Size.Width
            ? Size.Width
            : shape.Width;
        var height = startY + shape.Height > Size.Height
            ? Size.Height
            : shape.Height;

        if (!fill)
        {
            DrawLine(shape.UpperLeft, shape.UpperRight, color);
            DrawLine(shape.UpperLeft, shape.BottomLeft, color);
            DrawLine(shape.BottomLeft, shape.BottomRight, color);
            DrawLine(shape.UpperRight, shape.BottomRight, color);

            return;
        }

        for (var y = startY; y < startX + height - 1; y++)
        {
            for (var x = startX; x < startX + width - 1; x++)
            {
                PlotInternal(x, y, color);
            }
        }
    }

    /// <inheritdoc />
    public void FlipHorizontally()
    {
        var width = Size.Width;
        var height = Size.Height;
        var halfWidth = width / 2;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < halfWidth; x++)
            {
                (Data[x, y], Data[width - x - 1, y]) = (Data[width - x - 1, y], Data[x, y]);
            }
        }
    }

    private void PlotInternal(int x, int y, Color color)
    {
        _modified = true;
        Data[x, y] = color;
    }

    private void ReadRaw(IReadOnlyList<byte> data, PixelFormat format)
    {
        var width = Size.Width;
        var height = Size.Height;
        _modified = true;

        var stride = format switch
        {
            PixelFormat.Rgb  => 3,
            PixelFormat.Rgba => 4,
            PixelFormat.Argb => 4,
            _ => throw new ArgumentOutOfRangeException(
                nameof(PixelFormat),
                $"Not expected {nameof(PixelFormat)} value: {format}"
            )
        };
        var dataPointer = 0;
        Data = new Color[width, height];

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                Data[x, y] = GetPixel(dataPointer, data, format);
                dataPointer += stride;
            }
        }
    }

    private Color GetPixel(int pointer, IReadOnlyList<byte> data, PixelFormat format) =>
        format switch
        {
            PixelFormat.Rgb =>
                new Color(data[pointer], data[pointer + 1], data[pointer + 2]),
            PixelFormat.Argb =>
                new Color(data[pointer + 1], data[pointer + 2], data[pointer + 3], data[pointer]),
            PixelFormat.Rgba =>
                new Color(data[pointer], data[pointer + 1], data[pointer + 2], data[pointer + 3]),
            _ => throw new ArgumentOutOfRangeException(
                nameof(PixelFormat),
                $"Not expected {nameof(PixelFormat)} value: {format}"
            )
        };
}
