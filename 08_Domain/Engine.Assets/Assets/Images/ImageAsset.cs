using Engine.Assets.FileIO;
using Engine.Core.Math.Base;
using Engine.Core.Memory.Pixmap;

namespace Engine.Assets.Assets.Images;

/// <summary>
///     Implementation of <see cref="IAsset{T}" />
/// </summary>
public sealed class ImageAsset : IAsset<Pixmap>
{
    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public string SourcePath { get; private set; }

    /// <inheritdoc />
    public Pixmap Data { get; private set; }

    /// <summary>
    ///     Create new instance of <see cref="IAsset{T}" />
    /// </summary>
    public ImageAsset()
    {
        Data = null!;
        SourcePath = string.Empty;
        Id = Guid.NewGuid();
    }

    /// <inheritdoc />
    public void LoadAsset(string path)
    {
        SourcePath = path;
        LoadData(File.OpenRead(path));
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }

    private void LoadData(Stream dataStream)
    {
        using var fileReader = new FileReader(dataStream);
        fileReader.ReadHeader();

        if (fileReader.FileAssetDataType != AssetDataType.ImageData)
        {
            throw new InvalidDataException($"Asset expecting {nameof(AssetDataType.ImageData)} but found '{fileReader.FileAssetDataType}'");
        }

        fileReader.Read("Width", out int width);
        fileReader.Read("Height", out int height);
        fileReader.Read("Data", out byte[] tmpData);

        Data = new Pixmap(new Size(width, height), tmpData, PixelFormat.Rgba);
    }
}
