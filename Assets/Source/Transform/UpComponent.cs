using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class UpComponent : IComponent
{
    public Vector3 Value;
}