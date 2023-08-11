using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;

namespace Engine.Core.Memory.Pixmap;

public interface IPixmap
{
    /// <summary>
    ///     Pixel data for the pixmap, data format is always RGBA
    /// </summary>
    Color[,] Data { get; }

    /// <summary>
    ///     Width and Height of a pixmap
    /// </summary>
    Size Size { get; }

    /// <summary>
    ///     Convert the <see cref="Color" /> data into 1 dimensional byte array for use in graphics api like
    ///     <see cref="ITexture" />
    /// </summary>
    /// <remarks>It will always be in format <b>RGBA</b>.</remarks>
    /// <returns></returns>
    byte[] GetRaw();

    /// <summary>
    ///     Set the raw data of the pixmap
    /// </summary>
    /// <param name="data"></param>
    void SetRaw(byte[] data);

    /// <summary>
    ///     Copy an <see cref="Rect" /> area from a <see cref="Pixmap" /> into another new <see cref="Pixmap" />
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    IPixmap GetArea(Rect area);

    /// <summary>
    ///     Clear the entire pixmap with the given <paramref name="color" />
    /// </summary>
    /// <param name="color"><see cref="Color" /> to clear the pixmap with</param>
    void Clear(Color color);

    /// <summary>
    ///     Draw another <see cref="Pixmap" /> onto the pixmap buffer
    /// </summary>
    /// <param name="source">Source <see cref="Pixmap" /> to draw</param>
    /// <param name="x"><paramref name="x" /> position to draw pixmap</param>
    /// <param name="y"><paramref name="y" /> position to draw pixmap</param>
    /// <param name="mode">set the <see cref="BlendMode" /> for the blending</param>
    void DrawPixmap(Pixmap source, BlendMode mode, int x = 0, int y = 0);

    /// <summary>
    ///     Draw a simple pixel to pixmap at position <paramref name="x" /> and <paramref name="y" />
    /// </summary>
    /// <param name="x">X position of the pixel</param>
    /// <param name="y">Y position of the pixel</param>
    /// <param name="color"><see cref="Color" /> of the pixel</param>
    /// <param name="mode"><see cref="BlendMode" /> to blend both together</param>
    void Plot(int x, int y, Color color, BlendMode mode);

    /// <summary>
    ///     Draws a line on the pixmap <see cref="Pixmap" />
    /// </summary>
    void DrawLine(Point start, Point end, Color color);

    /// <summary>
    ///     Draws a line on the pixmap <see cref="Pixmap" />
    /// </summary>
    void DrawLine(int startX, int startY, int endX, int endY, Color color);

    /// <summary>
    ///     Draw a rect on the <see cref="Pixmap" />
    /// </summary>
    void DrawRect(int x, int y, int width, int height, Color color, bool fill);

    /// <summary>
    ///     Draw a rect on the <see cref="Pixmap" />
    /// </summary>
    void DrawRect(Rect shape, Color color, bool fill);

    /// <summary>
    ///     Flips a <see cref="Pixmap" /> horizontally
    /// </summary>
    void FlipHorizontally();
}
