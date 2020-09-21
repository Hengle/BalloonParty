using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class ScaleComponent : IComponent
{
    public Vector3 Value;
}