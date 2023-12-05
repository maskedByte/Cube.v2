using Engine.Core.Configurations;

namespace Engine.Core.Driver.Window.Configurations;

/// <summary>
///     Configuration for window context
/// </summary>
public record WindowContextConfiguration
{
    private bool _debugContext;
    private int _majorVersion = 4;
    private int _minorVersion = 5;
    private int _depthBits = 24;
    private int _stencilBits = 8;
    private int _samples;
    private bool _verticalSync = true;
    private int _maxFramerate;

    public bool DebugContext
    {
        get => _debugContext;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.DebugContext", value);
            _debugContext = value;
        }
    }

    public int MajorVersion
    {
        get => _majorVersion;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.MajorVersion", value);
            _majorVersion = value;
        }
    }

    public int MinorVersion
    {
        get => _minorVersion;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.MinorVersion", value);
            _minorVersion = value;
        }
    }

    public int DepthBits
    {
        get => _depthBits;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.DepthBits", value);
            _depthBits = value;
        }
    }

    public int StencilBits
    {
        get => _stencilBits;
        set
        {
            Configuration.Instance.Get("Context.OpenGl.StencilBits", value);
            _stencilBits = value;
        }
    }

    public int Samples
    {
        get => _samples;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.AntialiasingLevel", value);
            _samples = value;
        }
    }

    public bool VerticalSync
    {
        get => _verticalSync;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.VerticalSync", value);
            _verticalSync = value;
        }
    }

    public int MaxFramerate
    {
        get => _maxFramerate;
        set
        {
            Configuration.Instance.Set("Context.OpenGl.MaxFramerate", value);
            _maxFramerate = value;
        }
    }
}
