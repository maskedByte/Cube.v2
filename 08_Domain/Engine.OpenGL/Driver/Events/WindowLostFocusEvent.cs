using Engine.Core.Events;

namespace Engine.OpenGL.Driver.Events;

public class WindowLostFocusEvent : Event<bool>
{
    public WindowLostFocusEvent(bool data)
        : base(data)
    {
    }
}
