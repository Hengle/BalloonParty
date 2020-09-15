using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// This component is attached to game events
/// </summary>
[Event(EventTarget.Any)]
public sealed class GameEventComponent : IComponent
{
}