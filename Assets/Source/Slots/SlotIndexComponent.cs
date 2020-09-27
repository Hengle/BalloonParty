using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class SlotIndexComponent : IComponent
{
    public Vector2Int Value;
}