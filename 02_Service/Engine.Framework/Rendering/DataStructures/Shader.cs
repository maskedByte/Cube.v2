using Engine.Assets.Assets.Shaders;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.DataStructures;

public struct Shader
{
    internal static EngineCore Core { get; set; } = null!;
    internal IShaderProgram InternalShaderProgram { get; }

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

        var context = Core.ActiveDriver.GetContext();
        if (context is null)
        {
            Log.LogMessageAsync("Failed to get context.", LogLevel.Error, this);
            return;
        }

        InternalShaderProgram = context.CreateShaderProgram();
        Name = $"ShaderProgram-{InternalShaderProgram.GetId()}";

        var hasShader = false;

        if (shaderAsset.HasShader(ShaderAssetType.Vertex))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Vertex,
                    shaderAsset.Data[ShaderAssetType.Vertex]
                )
            );
            hasShader = true;
        }

        if (shaderAsset.HasShader(ShaderAssetType.Fragment))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Fragment,
                    shaderAsset.Data[ShaderAssetType.Fragment]
                )
            );
            hasShader = true;
        }

        if (shaderAsset.HasShader(ShaderAssetType.Geometry))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Geometry,
                    shaderAsset.Data[ShaderAssetType.Geometry]
                )
            );
            hasShader = true;
        }

        if (shaderAsset.HasShader(ShaderAssetType.TessellationControl))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.TessellationControl,
                    shaderAsset.Data[ShaderAssetType.TessellationControl]
                )
            );
            hasShader = true;
        }

        if (shaderAsset.HasShader(ShaderAssetType.TessellationEvaluation))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.TessellationEvaluation,
                    shaderAsset.Data[ShaderAssetType.TessellationEvaluation]
                )
            );
            hasShader = true;
        }

        if (shaderAsset.HasShader(ShaderAssetType.Compute))
        {
            InternalShaderProgram.AddShader(
                context.CreateShader(
                    ShaderSourceType.Compute,
                    shaderAsset.Data[ShaderAssetType.Compute]
                )
            );
            hasShader = true;
        }

        if (hasShader == false)
        {
            Log.LogMessageAsync("No shader found.", LogLevel.Error, this);
            throw new Exception("No shader found.");
        }

        InternalShaderProgram.Compile();

        foreach (var uniformBuffer in IContext.CurrentState.UniformBuffers)
        {
            uniformBuffer.Attach(InternalShaderProgram);
        }
    }
}
