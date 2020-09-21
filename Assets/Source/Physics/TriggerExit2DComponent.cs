using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class TriggerExit2DComponent : IComponent
{
    public Collider2D Value;
}