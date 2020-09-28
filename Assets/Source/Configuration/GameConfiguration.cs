using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Game Configuration", fileName = "GameConfiguration")]
public class GameConfiguration : ScriptableObject, IGameConfiguration
{
    [Header("Thrower")] [SerializeField] private Vector2 _throwerSpawnPoint;

    [Header("Projectile")] [SerializeField]
    private Vector2 _projectileSpawnPoint;

    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Vector4 _limitsClockwise;

    [Header("Slots")] [SerializeField] private Vector2Int _slotsSize;
    [SerializeField] private Vector2 _slotSeparation;
    [SerializeField] private Vector2 _slotsOffset;

    [Header("Balloons")] [SerializeField] private Vector2 _balloonSpawnAnimationSpeedRange;
    [SerializeField] private float _gameStartedBalloonLinesTimeInterval;
    [SerializeField] private int _gameStartedBalloonLines;

    public Vector2 ThrowerSpawnPoint => _throwerSpawnPoint;
    public Vector2 ProjectileSpawnPoint => _projectileSpawnPoint;
    public float ProjectileSpeed => _projectileSpeed;
    public Vector4 LimitsClockwise => _limitsClockwise;
    public Vector2 SlotSeparation => _slotSeparation;
    public Vector2 SlotsOffset => _slotsOffset;
    public Vector2Int SlotsSize => _slotsSize;
    public Vector2 BalloonSpawnAnimationSpeedRange => _balloonSpawnAnimationSpeedRange;

    public float GameStartedBalloonLinesTimeInterval => _gameStartedBalloonLinesTimeInterval;

    public int GameStartedBalloonLines => _gameStartedBalloonLines;
}