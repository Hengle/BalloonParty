using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class LayerComponent : IComponent
{
    public int Value;
}