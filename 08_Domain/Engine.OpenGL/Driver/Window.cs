using Engine.Core.Configurations;
using Engine.Core.Driver.Window;
using Engine.Core.Driver.Window.Configurations;
using Engine.Core.Events;
using Engine.Core.Math.Base;
using Engine.OpenGL.Driver.Events;
using Engine.OpenGL.Vendor.SFML.Window;
using SFML.System;

namespace Engine.OpenGL.Driver;

/// <summary>
///     Implementation of IWindow using SFML
/// </summary>
public sealed class Window : IWindow
{
    private readonly Vendor.SFML.Window.Window _internalWindow;
    private bool _cursorGrabbed;
    private bool _cursorVisible;
    private Input? _input;
    private bool _isTerminated;
    private Viewport _viewport;

    /// <inheritdoc />
    public bool CursorVisible
    {
        get => _cursorVisible;
        set
        {
            _cursorVisible = value;
            _internalWindow.SetMouseCursorVisible(_cursorVisible);
        }
    }

    /// <inheritdoc />
    public bool CursorGrabbed
    {
        get => _cursorGrabbed;
        set
        {
            _cursorGrabbed = value;
            _internalWindow.SetMouseCursorGrabbed(_cursorGrabbed);
        }
    }

    /// <inheritdoc />
    public Viewport Viewport
    {
        get
        {
            var position = _internalWindow.Position;
            var size = _internalWindow.Size;
            return new Viewport(position.X, position.Y, size.X, size.Y);
        }
        set => SetSize(value.Width, value.Height);
    }

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="configuration">The window creation configuration</param>
    /// <exception cref="Exception">Throws exception if window creation failed</exception>
    public Window(WindowCreationConfiguration configuration)
    {
        _input = null;

        var style = Styles.Titlebar | Styles.Close;
        if (configuration.WindowStyle.ResizeAble)
        {
            style = Styles.Titlebar | Styles.Close | Styles.Resize;
        }

        if (configuration.WindowStyle.Borderless)
        {
            style = Styles.None;
        }

        if (configuration.WindowStyle.Fullscreen)
        {
            style = Styles.Fullscreen;
        }

        var contextSettings = new ContextSettings
        {
            MajorVersion = (uint)configuration.WindowContext.MajorVersion,
            MinorVersion = (uint)configuration.WindowContext.MinorVersion,
            DepthBits = (uint)configuration.WindowContext.DepthBits,
            StencilBits = (uint)configuration.WindowContext.StencilBits,
            AntialiasingLevel = (uint)configuration.WindowContext.Samples
        };

        var viewMode = new VideoMode((uint)configuration.CanvasSize.Width, (uint)configuration.CanvasSize.Height);

        _internalWindow = new Vendor.SFML.Window.Window(
            viewMode,
            Configuration.Instance.Get("Window.WindowTitle", "Cube.Engine"),
            style,
            contextSettings
        );

        if (_internalWindow == null)
        {
            throw new Exception("Failed to create window");
        }

        _viewport = new Viewport
        {
            X = 0,
            Y = 0,
            Width = (int)viewMode.Width,
            Height = (int)viewMode.Height
        };
        _internalWindow.SetActive(configuration.WindowStyle.Active);
        _internalWindow.SetVerticalSyncEnabled(configuration.WindowContext.VerticalSync);
    }

    /// <inheritdoc />
    public void Terminate() => _isTerminated = true;

    /// <inheritdoc />
    public bool WindowTerminated() => _isTerminated;

    /// <inheritdoc />
    public void RequestFocus() => _internalWindow.RequestFocus();

    /// <inheritdoc />
    public void SetSize(int width, int height)
    {
        Configuration.Instance.Set("Window.Width", width);
        Configuration.Instance.Set("Window.Height", height);

        _internalWindow.Size = new Vector2u((uint)width, (uint)height);
        _viewport = new Viewport
        {
            X = 0,
            Y = 0,
            Width = width,
            Height = height
        };

        EventBus.Publish(new ViewportChangedEvent(_viewport));
    }

    /// <inheritdoc />
    public void SetPosition(int x, int y) => _internalWindow.Position = new Vector2i(x, y);

    /// <inheritdoc />
    public void SetTitle(string title)
    {
        Configuration.Instance.Set("Defaults.WindowTitle", title);
        _internalWindow.SetTitle(title);
    }

    /// <inheritdoc />
    public void SetVSync(bool vSync)
    {
        Configuration.Instance.Set("Window.VSync", vSync);
        _internalWindow.SetVerticalSyncEnabled(vSync);
    }

    /// <inheritdoc />
    public void SetVisible(bool visible) => _internalWindow.SetVisible(visible);

    /// <inheritdoc />
    public void SetFullscreen(bool fullscreen) => Configuration.Instance.Set("Window.Fullscreen", true);

    /// <inheritdoc />
    public void Display() => _internalWindow.Display();

    /// <inheritdoc />
    public void Close() => _internalWindow.Close();

    /// <inheritdoc />
    public void HandleEvents()
    {
        while (_internalWindow.PollEvents(out var windowEvent))
        {
            switch (windowEvent.Type)
            {
                case EventType.Closed:
                    _isTerminated = true;
                    break;

                case EventType.Resized:
                    _viewport = new Viewport
                    {
                        X = 0,
                        Y = 0,
                        Width = (int)windowEvent.Size.Width,
                        Height = (int)windowEvent.Size.Height
                    };
                    EventBus.Publish(new ViewportChangedEvent(_viewport));
                    break;

                case EventType.GainedFocus:
                    EventBus.Publish(new WindowGainedFocusEvent(true));
                    break;

                case EventType.LostFocus:
                    EventBus.Publish(new WindowLostFocusEvent(true));
                    break;

                case EventType.SensorChanged:
                    //if (SensorChanged != null)
                    //{
                    //    SensorChanged(this, new SensorEventArgs(e.Sensor));
                    //}
                    break;

                default:
                    _input?.Handle(windowEvent);
                    break;
            }
        }
    }

    /// <summary>
    ///     Set the input handler
    /// </summary>
    /// <param name="input">The input handler</param>
    public void SetInput(Input input) => _input = input;
}
