using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class BalloonLineSpawnerSystem : ReactiveSystem<GameEntity>, ILinkedViewListener
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;

    public BalloonLineSpawnerSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonLineInstanceEvent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isBalloonLineInstanceEvent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            var bottomSlotsIndexes = _contexts.game.BottomSlotsIndexes();

            foreach (Vector2Int index in bottomSlotsIndexes)
            {
                var e = _contexts.game.CreateEntity();
                e.isBalloon = true;
                e.AddSlotIndex(index);
                e.AddScale(Vector3.zero);

                // color
                var colorIndex = Random.Range(0, _configuration.BalloonColors.Length);
                e.AddBalloonColor(_configuration.BalloonColors[colorIndex]);

                // positioning for animation
                var initialPos = (index + Vector2Int.up * 4).IndexToPosition(_configuration);
                e.AddPosition(initialPos);

                // create balloon asset instance
                e.AddAsset("Balloon");
                e.AddLinkedViewListener(this);
            }
        }

        foreach (var gameEntity in entities.ToList())
        {
            gameEntity.Destroy();
        }
    }

    public void OnLinkedView(GameEntity entity, ILinkedView value)
    {
        var mono = value as MonoBehaviour;

        if (mono != null)
        {
            var time = Random.Range(_configuration.BalloonSpawnAnimationSpeedRange.x,
                _configuration.BalloonSpawnAnimationSpeedRange.y);

            var positionTween = mono.transform.DOMove(entity.slotIndex.Value.IndexToPosition(_configuration), time);
            var scaleTween = mono.transform.DOScale(Vector3.one, time);

            positionTween.onUpdate += () => { entity.ReplacePosition(mono.transform.position); };
            scaleTween.onUpdate += () => { entity.ReplaceScale(mono.transform.localScale); };
            positionTween.onComplete += () => { entity.isStableBalloon = true; };
        }

        entity.RemoveLinkedViewListener(this);
    }
}