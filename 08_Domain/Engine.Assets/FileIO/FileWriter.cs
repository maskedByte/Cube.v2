using System.IO.Compression;
using Engine.Assets.Assets;
using Engine.Core.Files;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Assets.FileIO;

/// <summary>
///     Create a new asset file from given data
/// </summary>
public sealed class FileWriter : IDisposable
{
    private readonly BinaryWriter _baseStream;
    private readonly BrotliStream _brotliStream;
    private readonly FileStream _fileStream;

    /// <summary>
    ///     Create new asset file and write data top
    /// </summary>
    /// <param name="filePath"></param>
    public FileWriter(string filePath)
    {
        _fileStream = filePath.AsFileStream(FileMode.Create, FileAccess.ReadWrite);
        _brotliStream = new BrotliStream(_fileStream, CompressionMode.Compress);
        _baseStream = new BinaryWriter(_brotliStream);
    }

    /// <summary>
    ///     Close file and dispose memory
    /// </summary>
    public void Dispose()
    {
        Close();

        _baseStream.Dispose();
        _brotliStream.Dispose();
        _fileStream.Dispose();
    }

    /// <summary>
    ///     Write header to AssetFile
    /// </summary>
    /// <param name="type"></param>
    public void WriteHeader(AssetDataType type)
    {
        _baseStream.Write("CubeAsset");
        _baseStream.Write(FileReader.CurrentVersion);
        _baseStream.Write((int)type);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, int data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, string data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, float data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, byte data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, bool data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, byte[] data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.Length);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, ReadOnlySpan<byte> data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.Length);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, long data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Vector2 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.X);
        _baseStream.Write(data.Y);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Vector3 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.X);
        _baseStream.Write(data.Y);
        _baseStream.Write(data.Z);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Vector4 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.X);
        _baseStream.Write(data.Y);
        _baseStream.Write(data.Z);
        _baseStream.Write(data.W);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Color data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.R);
        _baseStream.Write(data.G);
        _baseStream.Write(data.B);
        _baseStream.Write(data.A);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Matrix2 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.M11);
        _baseStream.Write(data.M12);
        _baseStream.Write(data.M21);
        _baseStream.Write(data.M22);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Matrix3 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.M11);
        _baseStream.Write(data.M12);
        _baseStream.Write(data.M13);
        _baseStream.Write(data.M21);
        _baseStream.Write(data.M22);
        _baseStream.Write(data.M23);
        _baseStream.Write(data.M31);
        _baseStream.Write(data.M32);
        _baseStream.Write(data.M33);
    }

    /// <summary>
    ///     Write data to AssetFile
    /// </summary>
    /// <param name="ident">Name of the key</param>
    /// <param name="data">Date which will be written</param>
    public void Write(string ident, Matrix4 data)
    {
        _baseStream.Write(ident);
        _baseStream.Write(data.M11);
        _baseStream.Write(data.M12);
        _baseStream.Write(data.M13);
        _baseStream.Write(data.M14);

        _baseStream.Write(data.M21);
        _baseStream.Write(data.M22);
        _baseStream.Write(data.M23);
        _baseStream.Write(data.M24);

        _baseStream.Write(data.M31);
        _baseStream.Write(data.M32);
        _baseStream.Write(data.M33);
        _baseStream.Write(data.M34);

        _baseStream.Write(data.M41);
        _baseStream.Write(data.M42);
        _baseStream.Write(data.M43);
        _baseStream.Write(data.M44);
    }

    /// <summary>
    ///     Close stream
    /// </summary>
    public void Close()
    {
        _baseStream.Close();
        _brotliStream.Close();
        _fileStream.Close();
    }
}
