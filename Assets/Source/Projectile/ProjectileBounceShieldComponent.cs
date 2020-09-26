using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public sealed class ProjectileBounceShieldComponent : IComponent
{
    public int Value;
}