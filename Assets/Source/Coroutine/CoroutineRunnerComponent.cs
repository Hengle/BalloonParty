using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public class CoroutineRunnerComponent : IComponent
{
    public MonoBehaviour Value;
}