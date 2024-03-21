using Engine.Assets.Assets;
using Engine.Assets.Assets.Material;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Logging;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.DataStructures;

public class Material : IReloadAble<MaterialAsset>
{
    private static readonly Dictionary<string, Shader> _loadedShaders = new();
    internal static EngineCore Core { get; set; }

    public const string DefaultShaderSource = "shader\\default_lit";

    /// <summary>
    ///     Unique name of the material.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Diffuse texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D Diffuse { get; set; }

    /// <summary>
    ///     Detail texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? Detail { get; set; }

    /// <summary>
    ///     Metallic texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? Metallic { get; set; }

    /// <summary>
    ///     Normal texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? Normal { get; set; }

    /// <summary>
    ///     Height texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? Height { get; set; }

    /// <summary>
    ///     Emission texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? Emission { get; set; }

    /// <summary>
    ///     Detail mask texture of the material <see cref="Texture2D" />.
    /// </summary>
    public Texture2D? DetailMask { get; set; }

    /// <summary>
    ///     Shader of the material <see cref="Shader" />.
    /// </summary>
    public Shader Shader { get; set; }

    /// <summary>
    ///     Tiling of the material <see cref="Vector2" />.
    /// </summary>
    public Vector2 Tiling { get; set; }

    /// <summary>
    ///     Filter of the material <see cref="TextureFilter" />.
    /// </summary>
    public TextureFilter Filter { get; set; }

    /// <summary>
    ///     Color of the material <see cref="Color" />.
    /// </summary>
    public Color Color { get; set; }

    public Material()
    {
        if (Core == null)
        {
            throw new InvalidOperationException("Core is not initialized.");
        }

        Name = string.Empty;
        Color = Color.White;
        Filter = TextureFilter.Linear;
        Tiling = Vector2.One;
        Diffuse = new Texture2D(Color.White, new Size(16, 16));

        if (_loadedShaders.TryGetValue(DefaultShaderSource, out var shader))
        {
            Shader = shader;
        }
        else
        {
            Shader = new Shader(DefaultShaderSource);
            _loadedShaders.Add(DefaultShaderSource, Shader);
        }
    }

    public Material(string path)
        : this()
    {
        var materialAsset = Core.Load<MaterialAsset>(path);
        if (materialAsset == null)
        {
            Log.LogMessageAsync($"Failed to load material : {path}", LogLevel.Error, this);
            return;
        }

        Core.RegisterAssetReload(typeof(MaterialAsset), this);

        TryReload(materialAsset);
    }

    public void TryReload(MaterialAsset asset)
    {
        Name = $"Texture2D-{asset!.Id}";

        Diffuse = !string.IsNullOrEmpty(asset.Data.DiffuseTexture)
            ? new Texture2D(asset.Data.DiffuseTexture)
            : new Texture2D(Color.White, new Size(16, 16));
        Detail = !string.IsNullOrEmpty(asset.Data.DetailTexture)
            ? new Texture2D(asset.Data.DetailTexture)
            : null;
        Metallic = !string.IsNullOrEmpty(asset.Data.MetallicTexture)
            ? new Texture2D(asset.Data.MetallicTexture)
            : null;
        Normal = !string.IsNullOrEmpty(asset.Data.NormalTexture)
            ? new Texture2D(asset.Data.NormalTexture)
            : null;
        Height = !string.IsNullOrEmpty(asset.Data.HeightTexture)
            ? new Texture2D(asset.Data.HeightTexture)
            : null;
        Emission = !string.IsNullOrEmpty(asset.Data.EmissionTexture)
            ? new Texture2D(asset.Data.EmissionTexture)
            : null;
        DetailMask = !string.IsNullOrEmpty(asset.Data.DetailMaskTexture)
            ? new Texture2D(asset.Data.DetailMaskTexture)
            : null;

        Color = asset.Data.Color;
        Filter = asset.Data.Filter;
        Tiling = asset.Data.Tiling;

        if (_loadedShaders.TryGetValue(asset.Data.ShaderFile, out var shader))
        {
            Shader = shader;
        }
        else
        {
            Shader = new Shader(asset.Data.ShaderFile);
            _loadedShaders.Add(asset.Data.ShaderFile, Shader);
        }
    }

    public void Dispose()
    {
        Core.UnregisterAssetReload(this);

        Diffuse.Dispose();
        Detail?.Dispose();
        Metallic?.Dispose();
        Normal?.Dispose();
        Height?.Dispose();
        Emission?.Dispose();
        DetailMask?.Dispose();
        Shader.Dispose();
    }
}
