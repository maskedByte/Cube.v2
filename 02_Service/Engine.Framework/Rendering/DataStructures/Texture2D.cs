using Engine.Assets.Assets;
using Engine.Assets.Assets.Images;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Logging;
using Engine.Core.Math.Base;
using Engine.Core.Memory.Pixmap;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.DataStructures;

public class Texture2D : IReloadAble<ImageAsset>
{
    internal static EngineCore Core { get; set; } = null!;
    internal ITexture InternalTexture { get; private set; }

    public string Name { get; set; }

    public Texture2D()
    {
        if (Core == null)
        {
            Log.LogMessageAsync($"{nameof(EngineCore)} is not initialized.", LogLevel.Critical, this);
            throw new InvalidOperationException($"{nameof(EngineCore)} is not initialized.");
        }

        Name = string.Empty;
        InternalTexture = null!;

        Core.RegisterAssetReload(typeof(ImageAsset), this);
    }

    public Texture2D(Color color, Size size)
        : this()
    {
        var pixmap = new Pixmap(color, size);
        InternalTexture = Core.ActiveDriver
           .GetContext()!
           .CreateTexture(TextureBufferTarget.Texture2D, pixmap);

        Name = $"Texture2D-{InternalTexture.GetId()}";
    }

    public Texture2D(string path)
        : this()
    {
        if (string.IsNullOrEmpty(path))
        {
            Log.LogMessageAsync("Path must not be null or empty.", LogLevel.Error, this);
            return;
        }

        var image = Core.Load<ImageAsset>(path);
        if (image == null)
        {
            Log.LogMessageAsync($"Failed to load image : {path}", LogLevel.Error, this);
        }

        InternalTexture = Core.ActiveDriver
           .GetContext()!
           .CreateTexture(TextureBufferTarget.Texture2D, image!.Data);

        Name = $"Texture2D-{InternalTexture.GetId()}";
    }

    public Texture2D(ImageAsset asset)
        : this()
    {
        InternalTexture = Core.ActiveDriver
           .GetContext()!
           .CreateTexture(TextureBufferTarget.Texture2D, asset.Data);

        Name = $"Texture2D-{InternalTexture.GetId()}";
    }

    public void TryReload(ImageAsset asset)
    {
        if (InternalTexture is null)
        {
            InternalTexture = Core.ActiveDriver
               .GetContext()!
               .CreateTexture(TextureBufferTarget.Texture2D, asset.Data);
            return;
        }

        var newInternalTexture = Core.ActiveDriver
           .GetContext()!
           .CreateTexture(TextureBufferTarget.Texture2D, asset.Data);

        InternalTexture.Dispose();
        InternalTexture = newInternalTexture;
    }

    public void Dispose()
    {
        Core.UnregisterAssetReload(this);
        InternalTexture.Dispose();
    }
}
