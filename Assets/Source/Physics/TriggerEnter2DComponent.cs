using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class TriggerEnter2DComponent : IComponent
{
    public Collider2D Value;
}