using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class PlayParticleFXComponent : IComponent
{
    public string Value;
}