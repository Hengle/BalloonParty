using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Component that determines if an entity is linked
/// to an Object in the Unity layer
/// </summary>
[Event(EventTarget.Self)]
public sealed class LinkedViewComponent : IComponent
{
    public ILinkedView Value;
}