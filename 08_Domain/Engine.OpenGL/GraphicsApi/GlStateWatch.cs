﻿using Engine.Core.Driver.Graphics.Buffers;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.GraphicsApi;

/// <summary>
///     Watches the current state of different OpenGl buffers
/// </summary>
internal static class GlStateWatch
{
    private static readonly Dictionary<BufferTarget, uint> BoundBuffers = new();

    private static readonly Dictionary<(TextureTarget, uint), uint> BoundTextures = new();

    private static IBufferArray? boundBufferArray;

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

    public static void BindBufferArray(IBufferArray bufferArray)
    {
        if (boundBufferArray != null && boundBufferArray.GetId() == bufferArray.GetId())
        {
            return;
        }

        Gl.BindVertexArray(bufferArray.GetId());
        boundBufferArray = bufferArray;
    }

    public static void UnbindBufferArray()
    {
        if (boundBufferArray == null)
        {
            return;
        }

        Gl.BindVertexArray(0);
        boundBufferArray = null;
    }

    public static Dictionary<BufferTarget, uint> GetBoundBuffers() => new(BoundBuffers.Where(x => x.Value != 0).ToList());

    public static void BindTexture(TextureTarget textureTarget, uint textureUnit, uint textureId)
    {
        if (BoundTextures.TryGetValue((textureTarget, textureUnit), out var currentTextureId))
        {
            if (currentTextureId == textureId)
            {
                return;
            }

            Gl.BindTextureUnit(textureUnit, textureId);
            BoundTextures[(textureTarget, textureUnit)] = textureId;
        }
        else
        {
            Gl.BindTexture(textureTarget, textureId);
            Gl.BindTextureUnit(textureUnit, textureId);
            BoundTextures.Add((textureTarget, textureUnit), textureId);
        }
    }

    public static void UnbindTexture(TextureTarget textureTarget, uint i)
    {
        if (!BoundTextures.TryGetValue((textureTarget, i), out var currentTextureId))
        {
            return;
        }

        if (currentTextureId == 0)
        {
            return;
        }

        Gl.BindTextureUnit(i, 0);
        BoundTextures[(textureTarget, i)] = 0;
    }

    public static void UnbindAll()
    {
        foreach (var (target, _) in BoundBuffers)
        {
            UnbindBuffer(target);
        }

        foreach (var (target, textureUnit) in BoundTextures)
        {
            UnbindTexture(target.Item1, textureUnit);
        }

        UnbindBufferArray();
    }

    public static void UnbindTextures()
    {
        foreach (var (target, textureUnit) in BoundTextures)
        {
            UnbindTexture(target.Item1, textureUnit);
        }
    }

    public static void Dispose()
    {
        UnbindAll();
        BoundBuffers.Clear();
        BoundTextures.Clear();
    }
}
