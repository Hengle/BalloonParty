using Entitas;

/// <summary>
/// Component that determines if an entity is linked
/// to an Object in the Unity layer
/// </summary>
public sealed class LinkedViewComponent : IComponent
{
    public ILinkedView Value;
}