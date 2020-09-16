using Entitas;
using UnityEngine;

public class LoadedProjectileTransformSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _projectiles;

    public LoadedProjectileTransformSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
        _projectiles = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.LoadedProjectile));
    }

    public void Execute()
    {
        foreach (var projectile in _projectiles)
        {
            var thrower = _contexts.game.throwerEntity;
            var angle = Vector3.Angle(thrower.direction.Value, Vector3.right) - 90;

            var point = _configuration.ProjectileSpawnPoint;
            var center = thrower.position.Value;
            float s = Mathf.Sin(angle * Mathf.Deg2Rad);
            float c = Mathf.Cos(angle * Mathf.Deg2Rad);

            var rotatedX = c * (point.x - center.x) - s * (point.y - center.y) + center.x;
            var rotatedY = s * (point.x - center.x) + c * (point.y - center.y) + center.y;

            projectile.ReplacePosition(new Vector3(rotatedX, rotatedY, 0));
            projectile.ReplaceRotation(Quaternion.AngleAxis(angle, Vector3.forward));
            projectile.ReplaceDirection(thrower.direction.Value);
        }
    }
}