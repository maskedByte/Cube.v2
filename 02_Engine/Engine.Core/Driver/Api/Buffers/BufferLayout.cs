namespace Engine.Driver.Api.Buffers;

/// <summary>
/// Implementation of <see cref="IBufferLayout" />
/// </summary>
public sealed class BufferLayout : IBufferLayout
{
    private Dictionary<string, BufferElement> _elements;
    private int _stride;

    /// <summary>
    /// Default parameterless constructor
    /// </summary>
    public BufferLayout()
    {
        _elements = new Dictionary<string, BufferElement>();
        _stride = 0;
    }

    /// <summary>
    /// Create new instance of <see cref="BufferLayout" />
    /// </summary>
    public BufferLayout(IEnumerable<BufferElement> elements)
        : this()
    {
        _elements = elements.ToDictionary(element => element.Name);
        _stride = 0;
    }

    /// <inheritdoc />
    public BufferElement this[string name]
    {
        get { return _elements[name]; }
    }

    /// <inheritdoc />
    public void SetLayout(BufferElement[] elements)
    {
        ArgumentNullException.ThrowIfNull(elements);
        _elements = elements.ToDictionary(element => element.Name);
    }

    /// <inheritdoc />
    public void AddElement(BufferElement element)
    {
        _elements.Add(element.Name, element);
    }

    /// <inheritdoc />
    public int GetStride()
    {
        CalculateBufferAndStride();
        return _stride;
    }

    /// <inheritdoc />
    public BufferElement[] GetElements()
    {
        CalculateBufferAndStride();
        return _elements.Values.ToArray();
    }

    private void CalculateBufferAndStride()
    {
        if (!_elements.Any())
        {
            return;
        }

        var offset = 0;
        _stride = 0;

        foreach (var element in _elements.Values)
        {
            element.Offset = offset;
            offset += element.Size;
            _stride += element.Size;
        }
    }
}
