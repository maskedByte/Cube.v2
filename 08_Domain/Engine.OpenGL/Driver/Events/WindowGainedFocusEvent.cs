using Engine.Core.Events;

namespace Engine.OpenGL.Driver.Events;

public class WindowGainedFocusEvent : Event<bool>
{
    public WindowGainedFocusEvent(bool data)
        : base(data)
    {
    }
}
