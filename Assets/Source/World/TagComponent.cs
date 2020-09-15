using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class TagComponent : IComponent
{
    public string Value;
}