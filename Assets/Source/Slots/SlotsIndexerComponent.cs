using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

/// <summary>
/// This single component indexes game entities into slot
/// entity instances for faster lookup
/// </summary>
[Unique]
public class SlotsIndexerComponent : IComponent
{
    public IEntity[,] Value;
}