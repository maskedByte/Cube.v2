namespace Engine.Framework.Entities;

/// <summary>
///     Represents a layer that an entity can be assigned to for culling purposes.
/// </summary>
public enum CullingLayer
{
    Default,
    Environment,
    Water,
    Sky,
    Player,
    Enemies,
    Ui
}
