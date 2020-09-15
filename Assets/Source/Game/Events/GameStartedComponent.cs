using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// This component indicates the game started
/// </summary>
[Unique, Event(EventTarget.Any)]
public sealed class GameStartedComponent : IComponent
{
}