namespace Engine.Driver;

/// <summary>
/// The clear buffer flags
/// </summary>
[Flags]
public enum ClearBufferFlag
{
    ColorBufferBit = 2,
    DepthBufferBit = 4,
    StencilBufferBit = 8,
    AccumBufferBit = 16,
    AllBufferBits = ColorBufferBit | StencilBufferBit | DepthBufferBit
}
