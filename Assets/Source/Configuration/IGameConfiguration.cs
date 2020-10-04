using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Configuration, Unique, ComponentName("GameConfiguration")]
public interface IGameConfiguration
{
    Vector2 ThrowerSpawnPoint { get; }
    Vector2 ProjectileSpawnPoint { get; }
    float ProjectileSpeed { get; }
    Vector4 LimitsClockwise { get; }
    Vector2Int SlotsSize { get; }
    Vector2 SlotSeparation { get; }
    Vector2 SlotsOffset { get; }
    Vector2 BalloonSpawnAnimationDurationRange { get; }
    float GameStartedBalloonLinesTimeInterval { get; }
    int GameStartedBalloonLines { get; }

    Color[] BalloonColors { get; }
    float TimeForBalloonsBalance { get;}
}