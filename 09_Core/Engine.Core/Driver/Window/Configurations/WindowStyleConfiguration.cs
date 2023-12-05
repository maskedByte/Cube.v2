using Engine.Core.Configurations;

namespace Engine.Core.Driver.Window.Configurations;

/// <summary>
///     Configuration for window style
/// </summary>
public record WindowStyleConfiguration
{
    private bool _fullscreen;
    private bool _resizeAble;
    private bool _borderless;
    private bool _active = true;

    public bool Fullscreen
    {
        get => _fullscreen;
        set
        {
            Configuration.Instance.Set("Window.Fullscreen", value);
            _fullscreen = value;
        }
    }

    public bool ResizeAble
    {
        get => _resizeAble;
        set
        {
            Configuration.Instance.Get("Window.Resizeable", value);
            _resizeAble = value;
        }
    }

    public bool Borderless
    {
        get => _borderless;
        set
        {
            Configuration.Instance.Get("Window.Borderless", value);
            _borderless = value;
        }
    }

    public bool Active
    {
        get => _active;
        set
        {
            Configuration.Instance.Get("Window.Active", value);
            _active = value;
        }
    }
}
