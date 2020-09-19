using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Configuration, Unique, ComponentName("GameConfiguration")]
public interface IGameConfiguration
{
    Vector2 ThrowerSpawnPoint { get; }

    Vector2 ProjectileSpawnPoint { get; }
    float ProjectileSpeed { get; }
}