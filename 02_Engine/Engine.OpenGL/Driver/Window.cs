using Engine.Core.Configurations;
using Engine.Core.Driver.Window;
using Engine.Core.Events;
using Engine.Core.Math.Base;
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
    /// <param name="width">width of the window</param>
    /// <param name="height">Height of the window</param>
    /// <param name="vSync">VSync enabled</param>
    /// <param name="fullscreen">Fullscreen enabled</param>
    /// <param name="resizeAble">Set if the window is resizeable</param>
    /// <exception cref="Exception">Throws exception if window creation failed</exception>
    public Window(
        int width,
        int height,
        bool vSync,
        bool fullscreen,
        bool resizeAble
    )
    {
        _input = null;

        var oglMajorVersion = Configuration.Instance.Get("OpenGl.MajorVersion", 4);
        var oglMinorVersion = Configuration.Instance.Get("OpenGl.MinorVersion", 5);
        var oglDepthBits = Configuration.Instance.Get("OpenGl.DepthBits", 24);
        var oglStencilBits = Configuration.Instance.Get("OpenGl.StencilBits", 8);
        var oglAntialiasingLevel = Configuration.Instance.Get("OpenGl.AntialiasingLevel", 0);

        var windowWidth = Configuration.Instance.Get("Window.Width", width);
        var windowHeight = Configuration.Instance.Get("Window.Height", height);
        var windowVSync = Configuration.Instance.Get("Window.VSync", vSync);

        var windowResizeAble = Configuration.Instance.Get("Window.Resizeable", resizeAble);
        var windowFullScreen = Configuration.Instance.Get("Window.Fullscreen", fullscreen);

        var style = Styles.Titlebar | Styles.Close;
        if (windowResizeAble)
        {
            style = Styles.Titlebar | Styles.Close | Styles.Resize;
        }

        if (windowFullScreen)
        {
            style = Styles.Fullscreen;
        }

        var contextSettings = new ContextSettings
        {
            MajorVersion = (uint)oglMajorVersion,
            MinorVersion = (uint)oglMinorVersion,
            DepthBits = (uint)oglDepthBits,
            StencilBits = (uint)oglStencilBits,
            AntialiasingLevel = (uint)oglAntialiasingLevel
        };

        _internalWindow = new Vendor.SFML.Window.Window(
            new VideoMode((uint)windowWidth, (uint)windowHeight),
            Configuration.Instance.Get("Defaults.WindowTitle", "Cube.Engine"),
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
            Width = width,
            Height = height
        };
        _internalWindow.SetActive(true);
        _internalWindow.SetVerticalSyncEnabled(windowVSync);
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

        EventBus.Dispatch("Window.ViewportChangedEvent", _viewport);
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
                    EventBus.Dispatch("Window.ViewportChangedEvent", _viewport);
                    break;

                case EventType.GainedFocus:
                    EventBus.Dispatch("Window.GainedFocusEvent", _viewport);
                    break;

                case EventType.LostFocus:
                    EventBus.Dispatch("Window.LostFocusEvent", _viewport);
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
