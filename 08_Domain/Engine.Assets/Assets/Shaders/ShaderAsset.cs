// ReSharper disable NonReadonlyMemberInGetHashCode
using Engine.Assets.FileIO;

namespace Engine.Assets.Assets.Shaders;

/// <summary>
///     <see cref="ShaderAsset" /> implementation
/// </summary>
public sealed class ShaderAsset : IAsset<Dictionary<ShaderAssetType, string>>
{
    private Dictionary<string, string> _config;
    private string _shaderData;

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public string SourcePath { get; private set; }

    /// <inheritdoc />
    public Dictionary<ShaderAssetType, string> Data { get; }

    /// <summary>
    ///     Create new instance of <see cref="IAsset{T}" />
    /// </summary>
    public ShaderAsset()
    {
        Data = new Dictionary<ShaderAssetType, string>();
        SourcePath = string.Empty;
        Id = Guid.NewGuid();

        _shaderData = string.Empty;

        _config = new Dictionary<string, string>();
    }

    /// <inheritdoc />
    public void LoadAsset(string path)
    {
        SourcePath = path;
        using var assetFile = new FileReader(path);
        LoadData(assetFile);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // Not needed here, because no unmanaged resources
    }

    /// <summary>
    ///     Returns shader of type <see cref="ShaderAssetType" />
    /// </summary>
    /// <param name="type"><see cref="ShaderAssetType" /> to return the string of this shader</param>
    /// <returns>String which contains the shader program</returns>
    public string GetShaderSource(ShaderAssetType type) => Data[type];

    /// <summary>
    ///     Check if this shader contains the <see cref="ShaderAssetType" /> type of a shader
    /// </summary>
    /// <param name="type">Shader type to check</param>
    /// <returns>True if a shader of <paramref name="type" /> was loaded</returns>
    public bool HasShader(ShaderAssetType type) => !string.IsNullOrEmpty(Data[type]);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(Data, _config.GetHashCode().ToString());

    private void LoadData(FileReader assetReader)
    {
        assetReader.ReadHeader();
        if (assetReader.FileAssetDataType != AssetDataType.ShaderData)
        {
            throw new InvalidDataException($"Asset expecting {nameof(ShaderAsset)} but found '{assetReader.FileAssetDataType}'");
        }

        assetReader.Read("Data", out string sourceData);
        ReadShader(sourceData);
    }

    private void ReadShader(string shaderData)
    {
        if (string.IsNullOrWhiteSpace(shaderData))
        {
            throw new ArgumentNullException(nameof(shaderData));
        }

        _shaderData = shaderData;
        _shaderData = _shaderData.Trim();

        GetConfigBlock();
        Data.Add(ShaderAssetType.Vertex, GetShaderBlock("Vertex").Trim());
        Data.Add(ShaderAssetType.Fragment, GetShaderBlock("Fragment").Trim());
        Data.Add(ShaderAssetType.Geometry, GetShaderBlock("Geometry").Trim());
        Data.Add(ShaderAssetType.Compute, GetShaderBlock("Compute").Trim());
        Data.Add(ShaderAssetType.TessellationControl, GetShaderBlock("TessellationControl").Trim());
        Data.Add(ShaderAssetType.TessellationEvaluation, GetShaderBlock("TessellationEvaluation").Trim());
    }

    private void GetConfigBlock()
    {
        const string blockStart = ":Config";

        if (!_shaderData.Contains(blockStart))
        {
            throw new EntryPointNotFoundException("Shader does not contains configurations!");
        }

        var configData = GetData(blockStart)
           .Trim()
           .Split(";")
           .Where(s => !string.IsNullOrEmpty(s))
           .Select(s => s.Trim());

        _config = configData
           .ToDictionary(
                s => s.Split("=")[0],
                s => s.Split("=")[1].Replace("\"", "")
            );
    }

    private string GetShaderBlock(string typeName)
    {
        var blockStart = $":Shader(Type=\"{typeName}\")";

        if (!_shaderData.Contains(blockStart))
        {
            return string.Empty;
        }

        var data = GetData(blockStart);

        if (_config.TryGetValue("Version", out var value))
        {
            data = data.Insert(0, value);
        }

        return data;
    }

    private string GetData(string blockStart)
    {
        GetEndBlockPositions(
            _shaderData.IndexOf(blockStart, StringComparison.Ordinal),
            out var blkStart,
            out var blkEnd
        );
        return _shaderData.Substring(blkStart, blkEnd - blkStart);
    }

    private void GetEndBlockPositions(int startPos, out int blockStart, out int blockEnd)
    {
        blockStart = startPos;
        blockEnd = startPos;
        var endScope = -1;

        for (var i = startPos; i < _shaderData.Length; i++)
        {
            var c = _shaderData[i];

            switch (c.ToString())
            {
                case "{":
                {
                    if (endScope == -1)
                    {
                        endScope = 0;
                        blockStart = i + 1;
                    }

                    endScope++;
                    break;
                }
                case "}":
                    endScope--;
                    break;
            }

            if (endScope != 0)
            {
                continue;
            }

            blockEnd = i;
            return;
        }
    }
}
