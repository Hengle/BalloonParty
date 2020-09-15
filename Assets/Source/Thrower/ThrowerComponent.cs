using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Self)]
public class ThrowerComponent : IComponent
{
}