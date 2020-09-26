using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProjectileBounceSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IGroup<GameEntity> _freeProjectiles;

    public ProjectileBounceSystem(Contexts contexts)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
        _freeProjectiles = _contexts.game.GetGroup(GameMatcher.FreeProjectile);
    }

    public void Execute()
    {
        foreach (var freeProjectile in _freeProjectiles)
        {
            var position = freeProjectile.position.Value;
            var direction = freeProjectile.direction.Value;
            var reflect = Vector3.zero;

            // top limit
            if (position.y > _configuration.LimitsClockwise.x)
            {
                reflect += Vector3.down;
            }

            // right limit
            if (position.x > _configuration.LimitsClockwise.y)
            {
                reflect += Vector3.left;
            }

            // bottom limit
            if (position.y < _configuration.LimitsClockwise.z)
            {
                reflect += Vector3.up;
            }

            // left limit
            if (position.x < _configuration.LimitsClockwise.w)
            {
                reflect += Vector3.right;
            }

            freeProjectile.ReplaceDirection(Vector2.Reflect(direction, reflect.normalized));
        }

#if UNITY_EDITOR
        Debug.DrawLine(Vector3.up * _configuration.LimitsClockwise.x + Vector3.right * 100,
            Vector3.up * _configuration.LimitsClockwise.x - Vector3.right * 100, Color.red);
        Debug.DrawLine(Vector3.right * _configuration.LimitsClockwise.y + Vector3.up * 100,
            Vector3.right * _configuration.LimitsClockwise.y - Vector3.up * 100, Color.red);
        Debug.DrawLine(Vector3.up * _configuration.LimitsClockwise.z + Vector3.right * 100,
            Vector3.up * _configuration.LimitsClockwise.z - Vector3.right * 100, Color.red);
        Debug.DrawLine(Vector3.right * _configuration.LimitsClockwise.w + Vector3.up * 100,
            Vector3.right * _configuration.LimitsClockwise.w - Vector3.up * 100, Color.red);
#endif
    }
}