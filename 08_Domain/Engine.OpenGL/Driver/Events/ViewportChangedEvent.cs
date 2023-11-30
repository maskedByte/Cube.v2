using Engine.Core.Events;
using Engine.Core.Math.Base;

namespace Engine.OpenGL.Driver.Events;

public sealed class ViewportChangedEvent : Event<Viewport>
{
    public ViewportChangedEvent(Viewport data)
        : base(data)
    {
    }
}
