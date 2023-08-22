namespace Engine.Assets.Assets.Material;

internal class MaterialFile
{
    public Channels Channels { get; set; }
    public string Shader { get; set; } = "shader/default";
    public string Tiling { get; set; } = "1,1";
    public string Color { get; set; } = "255,255,255,255";
    public string Filter { get; set; } = "Linear";
}
