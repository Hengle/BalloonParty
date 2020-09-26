using Entitas;
using UnityEngine;

public class ThrowLoadedProjectileSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _throwers;

    public ThrowLoadedProjectileSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;

        _throwers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Thrower, GameMatcher.Movable,
            GameMatcher.Direction, GameMatcher.ReadyToThrow, GameMatcher.ThrowerLoadedProjectile));
    }

    public void Execute()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (var thrower in _throwers.GetEntities())
            {
                var pEntity = thrower.throwerLoadedProjectile.Value;
                pEntity.ReplaceSpeed(_configuration.ProjectileSpeed);
                pEntity.isLoadedProjectile = false;
                pEntity.isFreeProjectile = true;
                pEntity.AddProjectileBounceShield(1);

                // remove loaded projectile
                thrower.RemoveThrowerLoadedProjectile();
            }
        }
    }
}