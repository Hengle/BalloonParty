using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [Header("Thrower")] [SerializeField] private Vector2 _throwerSpawnPoint;

    [Header("Projectile")] [SerializeField]
    private Vector2 _projectileSpawnPoint;

    [SerializeField] private float _projectileSpeed;

    public Vector2 ThrowerSpawnPoint => _throwerSpawnPoint;

    public Vector2 ProjectileSpawnPoint => _projectileSpawnPoint;

    public float ProjectileSpeed => _projectileSpeed;
}