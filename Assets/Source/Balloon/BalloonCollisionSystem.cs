using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BalloonCollisionSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly int _layer;

    public BalloonCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _layer = LayerMask.NameToLayer("Balloons");
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

            // we are colliding with balloons
            if ((collider.gameObject.layer & _layer) > 0)
            {
                var linkedView = collider.GetComponent<ILinkedView>();

                if (linkedView.LinkedEntity is GameEntity balloonEntity && balloonEntity.isBalloon)
                {
                    var color = balloonEntity.balloonColor.Value;

                    if (!gameEntity.hasBalloonColor)
                    {
                        gameEntity.AddBalloonColor(color);
                        gameEntity.AddBalloonLastColorPopCount(1);
                    }
                    else
                    {
                        if (color == gameEntity.balloonColor.Value)
                        {
                            var colorCount = gameEntity.balloonLastColorPopCount.Value;
                            gameEntity.ReplaceBalloonLastColorPopCount(colorCount + 1);

                            // when 3 of the same color are hit, add an extra bounce shield
                            if (colorCount >= 2)
                            {
                                var shields = gameEntity.projectileBounceShield.Value;
                                gameEntity.ReplaceProjectileBounceShield(shields + 1);
                            }
                        }
                        else
                        {
                            gameEntity.ReplaceBalloonColor(color);
                        }
                    }

                    balloonEntity.isDestroyed = true;
                }
            }
        }
    }
}
