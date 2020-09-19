using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class SpeedComponent : IComponent
{
    public float Value;
}