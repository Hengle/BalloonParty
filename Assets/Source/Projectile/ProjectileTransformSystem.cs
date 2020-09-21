using Entitas;
using UnityEngine;

public class ProjectileTransformSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _loadedProjectiles;
    private readonly IGroup<GameEntity> _freeProjectiles;

    public ProjectileTransformSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
        _loadedProjectiles = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.LoadedProjectile));
        _freeProjectiles = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.FreeProjectile));
    }

    public void Execute()
    {
        // for loaded projectiles rotate around the thrower
        foreach (var loadedProjectile in _loadedProjectiles)
        {
            var thrower = _contexts.game.throwerEntity;

            if (!thrower.hasDirection) continue;

            var angle = Vector3.Angle(thrower.direction.Value, Vector3.right) - 90;

            var point = _configuration.ProjectileSpawnPoint;
            var center = thrower.position.Value;
            float s = Mathf.Sin(angle * Mathf.Deg2Rad);
            float c = Mathf.Cos(angle * Mathf.Deg2Rad);

            var rotatedX = c * (point.x - center.x) - s * (point.y - center.y) + center.x;
            var rotatedY = s * (point.x - center.x) + c * (point.y - center.y) + center.y;

            loadedProjectile.ReplacePosition(new Vector3(rotatedX, rotatedY, 0));
            loadedProjectile.ReplaceUp(thrower.direction.Value);
            loadedProjectile.ReplaceDirection(thrower.direction.Value);
        }

        // free projectiles follow the projectile direction
        foreach (var freeProjectile in _freeProjectiles)
        {
            freeProjectile.ReplaceUp(freeProjectile.direction.Value);
#if UNITY_EDITOR
            Debug.DrawRay(freeProjectile.position.Value, freeProjectile.direction.Value);
#endif
        }
    }
}