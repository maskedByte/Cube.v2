namespace Engine.Framework.Rendering.Materials;

public class Material : IDisposable
{
    internal static EngineCore? Framework { get; set; }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    public static Material Load(string path) => throw new NotImplementedException();
}
