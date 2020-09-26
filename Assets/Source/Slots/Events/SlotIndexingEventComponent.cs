using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Any)]
public class SlotIndexingEventComponent : IComponent
{
    public Vector2Int Value;
}