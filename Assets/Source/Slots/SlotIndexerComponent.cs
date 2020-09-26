using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// This single component indexes game entities into slot
/// entity instances for faster lookup
/// </summary>
[Game, Unique]
public class SlotIndexerComponent : IComponent
{
    public Dictionary<Vector2Int, IEntity> Value;
}