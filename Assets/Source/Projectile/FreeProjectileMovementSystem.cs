using Entitas;
using UnityEngine;

public class FreeProjectileMovementSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _projectiles;

    public FreeProjectileMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
        _projectiles = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.FreeProjectile,
            GameMatcher.Speed, GameMatcher.Direction));
    }

    public void Execute()
    {
        foreach (var projectile in _projectiles)
        {
            var position = projectile.position.Value;
            var direction = projectile.direction.Value;
            var speed = projectile.speed.Value;

            projectile.ReplacePosition(position + direction * speed * Time.deltaTime);
        }
    }
}