using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.GraphicsApi;

/// <summary>
///     Watches the current state of different OpenGl buffers
/// </summary>
internal static class GlStateWatch
{
    private static readonly Dictionary<BufferTarget, uint> BoundBuffers = new();

    private static readonly Dictionary<(TextureTarget, uint), uint> BoundTextures = new();

    public static void BindBuffer(BufferTarget target, uint bufferId)
    {
        if (BoundBuffers.TryGetValue(target, out var currentBufferId))
        {
            if (currentBufferId == bufferId)
            {
                return;
            }

            Gl.BindBuffer(target, bufferId);
            BoundBuffers[target] = bufferId;
        }
        else
        {
            Gl.BindBuffer(target, bufferId);
            BoundBuffers.Add(target, bufferId);
        }
    }

    public static void UnbindBuffer(BufferTarget target)
    {
        if (!BoundBuffers.TryGetValue(target, out var currentBufferId))
        {
            return;
        }

        if (currentBufferId == 0)
        {
            return;
        }

        BoundBuffers[target] = 0;
        Gl.BindBuffer(target, 0);
    }

    public static Dictionary<BufferTarget, uint> GetBoundBuffers() => new(BoundBuffers.Where(x => x.Value != 0).ToList());

    public static void BindTexture(TextureTarget target, uint textureUnit, uint textureId)
    {
        if (BoundTextures.TryGetValue((target, textureUnit), out var currentTextureId))
        {
            if (currentTextureId == textureId)
            {
                return;
            }

            Gl.BindTextureUnit(textureUnit, textureId);
            BoundTextures[(target, textureUnit)] = textureId;
        }
        else
        {
            Gl.BindTexture(target, textureId);
            Gl.BindTextureUnit(textureUnit, textureId);
            BoundTextures.Add((target, textureUnit), textureId);
        }
    }

    public static void UnbindTexture(TextureTarget texture2D, uint i)
    {
        if (!BoundTextures.TryGetValue((texture2D, i), out var currentTextureId))
        {
            return;
        }

        if (currentTextureId == 0)
        {
            return;
        }

        Gl.BindTextureUnit(i, 0);
        BoundTextures[(texture2D, i)] = 0;
    }
}
