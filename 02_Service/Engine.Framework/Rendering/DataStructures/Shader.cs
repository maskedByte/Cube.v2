using Engine.Assets.Assets;
using Engine.Assets.Assets.Shaders;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.DataStructures;

public class Shader : IReloadAble<ShaderAsset>
{
    internal static EngineCore Core { get; set; } = null!;
    internal IShaderProgram InternalShaderProgram { get; private set; }

    public string Name { get; set; }

    public Shader()
    {
        if (Core is null)
        {
            Log.LogMessageAsync($"{nameof(EngineCore)} is not initialized.", LogLevel.Critical, this);
            throw new InvalidOperationException($"{nameof(EngineCore)} is not initialized.");
        }

        InternalShaderProgram = null!;
        Name = string.Empty;

        Core.RegisterAssetReload(typeof(ShaderAsset), this);
    }

    public Shader(string path)
        : this()
    {
        if (string.IsNullOrEmpty(path))
        {
            Log.LogMessageAsync("Path must not be null or empty.", LogLevel.Error, this);
            return;
        }

        var shaderAsset = Core.Load<ShaderAsset>(path);
        if (shaderAsset is null)
        {
            Log.LogMessageAsync($"Failed to load image : {path}", LogLevel.Error, this);
            return;
        }

        TryReload(shaderAsset);
    }

    public void TryReload(ShaderAsset asset)
    {
        var context = Core.ActiveDriver.GetContext();
        if (context is null)
        {
            Log.LogMessageAsync("Failed to get context.", LogLevel.Error, this);
            return;
        }

        var newShaderProgram = context.CreateShaderProgram();
        Name = $"ShaderProgram-{newShaderProgram.GetId()}";

        var hasShader = false;

        if (asset.HasShader(ShaderAssetType.Vertex))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Vertex,
                    asset.Data[ShaderAssetType.Vertex]
                )
            );
            hasShader = true;
        }

        if (asset.HasShader(ShaderAssetType.Fragment))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Fragment,
                    asset.Data[ShaderAssetType.Fragment]
                )
            );
            hasShader = true;
        }

        if (asset.HasShader(ShaderAssetType.Geometry))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Geometry,
                    asset.Data[ShaderAssetType.Geometry]
                )
            );
            hasShader = true;
        }

        if (asset.HasShader(ShaderAssetType.TessellationControl))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.TessellationControl,
                    asset.Data[ShaderAssetType.TessellationControl]
                )
            );
            hasShader = true;
        }

        if (asset.HasShader(ShaderAssetType.TessellationEvaluation))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.TessellationEvaluation,
                    asset.Data[ShaderAssetType.TessellationEvaluation]
                )
            );
            hasShader = true;
        }

        if (asset.HasShader(ShaderAssetType.Compute))
        {
            newShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Compute,
                    asset.Data[ShaderAssetType.Compute]
                )
            );
            hasShader = true;
        }

        if (hasShader == false)
        {
            Log.LogMessageAsync("No shader found.", LogLevel.Error, this);
            throw new Exception("No shader found.");
        }

        newShaderProgram.Compile();

        foreach (var uniformBuffer in IContext.CurrentState.UniformBuffers)
        {
            uniformBuffer.Attach(newShaderProgram);
        }

        InternalShaderProgram?.Dispose();
        InternalShaderProgram = newShaderProgram;
    }

    public void Dispose()
    {
        Core.UnregisterAssetReload(this);
        InternalShaderProgram.Dispose();
    }
}
