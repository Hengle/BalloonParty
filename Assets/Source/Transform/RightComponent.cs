using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class RightComponent : IComponent
{
    public Vector3 Value;
}