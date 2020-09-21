using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class RotationComponent : IComponent
{
    public Quaternion Value;
}