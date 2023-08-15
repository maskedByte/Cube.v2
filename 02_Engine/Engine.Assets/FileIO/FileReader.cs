using System.Data;
using System.IO.Compression;
using System.Numerics;
using Engine.Assets.AssetData;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;

namespace Engine.Assets.FileIO;

/// <summary>
///     Create a new asset file from given data
/// </summary>
public sealed class FileReader : IDisposable
{
    internal const string CurrentVersion = "1.0.0";
    private readonly BinaryReader _baseStream;
    private readonly BrotliStream _brotliStream;
    private readonly string? _fileName;
    private readonly FileStream? _fileStream;

    /// <summary>
    ///     Type of this asset file
    /// </summary>
    public AssetDataType FileAssetDataType { get; private set; }

    /// <summary>
    ///     Version of this asset file
    /// </summary>
    public string Version { get; private set; } = "0.0";

    /// <summary>
    ///     Create new asset file and write data top
    /// </summary>
    /// <param name="filePath">Path to load a file from</param>
    public FileReader(string filePath)
    {
        _fileStream = File.OpenRead(filePath);
        _brotliStream = new BrotliStream(_fileStream, CompressionMode.Decompress);
        _baseStream = new BinaryReader(_brotliStream);
        _fileName = filePath;
    }

    /// <summary>
    ///     Create new asset file and write data top
    /// </summary>
    /// <param name="fileStream"><see cref="Stream" /> to load a file from</param>
    public FileReader(Stream fileStream)
    {
        _fileStream = null!;
        _brotliStream = new BrotliStream(fileStream, CompressionMode.Decompress);
        _baseStream = new BinaryReader(_brotliStream);
        _fileName = fileStream.GetType().ToString();
    }

    /// <summary>
    ///     Close file and dispose memory
    /// </summary>
    public void Dispose()
    {
        Close();
        _baseStream.Dispose();
        _brotliStream.Dispose();
        _fileStream?.Dispose();
    }

    public void ReadHeader()
    {
        if (_baseStream.ReadString() != "CubeAsset")
        {
            throw new FormatException($"Unable to load asset file '{_fileName}' because header is invalid!");
        }

        Version = _baseStream.ReadString();
        if (Version != CurrentVersion)
        {
            throw new VersionNotFoundException($"Unable to load asset file '{_fileName}' because version ({Version}) is invalid!");
        }

        FileAssetDataType = (AssetDataType)_baseStream.ReadInt32();
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    ///     throw exception
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out int data)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadInt32();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out string data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadString();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out float data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadSingle();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out byte data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadByte();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out bool data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadBoolean();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out byte[] data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            var dataLen = _baseStream.ReadInt32();
            data = _baseStream.ReadBytes(dataLen);
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out long data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = _baseStream.ReadInt64();
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Vector2 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = new Vector2(_baseStream.ReadSingle(), _baseStream.ReadSingle());
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Vector3 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = new Vector3(
                _baseStream.ReadSingle(),
                _baseStream.ReadSingle(),
                _baseStream.ReadSingle()
            );
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Vector4 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            data = new Vector4(
                _baseStream.ReadSingle(),
                _baseStream.ReadSingle(),
                _baseStream.ReadSingle(),
                _baseStream.ReadSingle()
            );
            return;
        }

        throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Color data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (!name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
        }

        data = new Color(
            _baseStream.ReadByte(),
            _baseStream.ReadByte(),
            _baseStream.ReadByte(),
            _baseStream.ReadByte()
        );
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Matrix2 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (!name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
        }

        data = new Matrix2(
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle()
        );
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Matrix3 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (!name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
        }

        data = new Matrix3(
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle()
        );
    }

    /// <summary>
    ///     Read data from asset file into <paramref name="data" /> and check if identifier is equal otherwise
    /// </summary>
    /// <param name="name">Name of the expected identifier</param>
    /// <param name="data">Value read from AssetFile</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name" /> is null or empty</exception>
    /// <exception cref="InvalidDataException">If name is not equal the read identifier from AssetFile</exception>
    public void Read(string name, out Matrix4 data)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var ident = _baseStream.ReadString();
        if (!name.Equals(ident, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidDataException($"Invalid identifier found, expecting {name} but found {ident}");
        }

        data = new Matrix4(
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle(),
            _baseStream.ReadSingle()
        );
    }

    /// <summary>
    ///     Close stream
    /// </summary>
    public void Close()
    {
        _baseStream.Close();
        _brotliStream.Close();
        _fileStream?.Close();
    }
}
