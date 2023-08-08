namespace Engine.Driver;

/// <summary>
/// Bindable interface
/// </summary>
public interface IBindable
{
    /// <summary>
    /// Bind specific to stack
    /// </summary>
    public void Bind();

    /// <summary>
    /// Unbind specific from stack
    /// </summary>
    public void Unbind();
}
