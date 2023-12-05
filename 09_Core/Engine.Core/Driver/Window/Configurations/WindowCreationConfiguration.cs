using Engine.Core.Configurations;
using Engine.Core.Math.Base;

namespace Engine.Core.Driver.Window.Configurations;

/// <summary>
///     Configuration for window creation
/// </summary>
public record WindowCreationConfiguration
{
    private Size _canvasSize;
    private bool _showCursor = true;

    public WindowStyleConfiguration WindowStyle { get; set; } = new();
    public WindowContextConfiguration WindowContext { get; set; } = new();

    public Size CanvasSize
    {
        get => _canvasSize;
        set
        {
            Configuration.Instance.Set("Window.Width", value.Width);
            Configuration.Instance.Set("Window.Height", value.Height);

            _canvasSize = value;
        }
    }

    public bool ShowCursor
    {
        get => _showCursor;
        set
        {
            Configuration.Instance.Set("Window.ShowHwCursor", value);
            _showCursor = value;
        }
    }
}
