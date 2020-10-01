using System.Linq;
using Entitas;
using UnityEngine;

public class ThrowLoadedProjectileSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _throwers;
    private readonly IGroup<GameEntity> _balloons;

    public ThrowLoadedProjectileSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;

        _throwers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Thrower, GameMatcher.Movable,
            GameMatcher.Direction, GameMatcher.ReadyToThrow, GameMatcher.ThrowerLoadedProjectile));
        _balloons = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Balloon));
    }

    public void Execute()
    {
        // check if all current balloons are stable
        var unstable = _balloons.AsEnumerable().Any(x => !x.isStableBalloon);

        if (Input.GetMouseButtonUp(0) && !unstable)
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