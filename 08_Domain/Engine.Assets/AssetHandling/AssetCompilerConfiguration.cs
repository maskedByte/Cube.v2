namespace Engine.Assets.AssetHandling;

public struct AssetCompilerConfiguration
{
    public List<string>? CompileExtensions { get; set; }
    public bool DeleteCompiledFiles { get; set; }
}
