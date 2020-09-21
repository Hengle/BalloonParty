using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProjectileBounceSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private string _lastCollision;

    public ProjectileBounceSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.FreeProjectile, GameMatcher.TriggerEnter2D));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isFreeProjectile && entity.hasTriggerEnter2D;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            var collider = gameEntity.triggerEnter2D.Value;
            var direction = gameEntity.direction.Value;
            var reflect = Vector3.zero;

            switch (collider.tag)
            {
                case "LimitLeft":
                    reflect = Vector3.right;
                    break;
                case "LimitRight":
                    reflect = Vector3.left;
                    break;
                case "LimitTop":
                    reflect = Vector3.down;
                    break;
                case "LimitBottom":
                    reflect = Vector3.up;
                    break;
            }

            gameEntity.ReplaceDirection(Vector2.Reflect(direction, reflect));
        }
    }
}