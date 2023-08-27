using Engine.Core.Math.Base;
using Engine.Framework.Frameworks;

namespace Engine.Framework.Worlds;

public sealed class World : IDisposable
{
    public EngineCore Core { get; }
    public Transform Transform { get; set; }
    public Color AmbientLight { get; set; }

    public World(EngineCore core)
    {
        Core = core ?? throw new ArgumentNullException(nameof(core));
        Transform = new Transform();
        AmbientLight = Color.White;
    }

    public void Dispose()
    {
    }

    public void Update()
    {
    }

    public void Render()
    {
    }
}
