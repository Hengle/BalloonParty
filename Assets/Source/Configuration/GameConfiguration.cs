using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [SerializeField] private Vector2 _throwerSpawnPoint;
    [SerializeField] private Vector2 _projectileSpawnPoint;

    public Vector2 ThrowerSpawnPoint => _throwerSpawnPoint;

    public Vector2 ProjectileSpawnPoint => _projectileSpawnPoint;
}