using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using TMPro;
using UnityEngine;

public class BalanceBalloonsSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;
    private readonly IEntity[,] _slots;

    public BalanceBalloonsSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
        _slots = _contexts.game.slotsIndexer.Value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BalloonsBalanceEvent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isBalloonsBalanceEvent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var hasUnbalanced = true;
        var paths = new Dictionary<GameEntity, List<Vector3>>();

        while (hasUnbalanced)
        {
            hasUnbalanced = false;

            for (int i = 0; i < _slots.GetLength(0); i++)
            {
                for (int j = _slots.GetLength(1) - 1; j >= 0; j--)
                {
                    if (_slots.IsEmpty(i, j)) continue;
                    if (!(_slots[i, j] is GameEntity balloonEntity)) continue;
                    if (!_slots.IsUnbalanced(i, j)) continue;

                    var nextSlot = _slots.OptimalNextEmptySlot(i, j);

                    if (!nextSlot.HasValue) continue;

                    hasUnbalanced = true;

                    // swap index values
                    _slots[i, j] = null;
                    _slots[nextSlot.Value.x, nextSlot.Value.y] = balloonEntity;
                    balloonEntity.ReplaceSlotIndex(nextSlot.Value);

                    // save to movement path animation
                    if (paths.TryGetValue(balloonEntity, out var path))
                    {
                        path.Add(nextSlot.Value.IndexToPosition(_configuration));
                    }
                    else
                    {
                        paths.Add(balloonEntity, new List<Vector3>()
                        {
                            nextSlot.Value.IndexToPosition(_configuration)
                        });
                    }
                }
            }
        }

        foreach (var path in paths)
        {
            var mono = path.Key.linkedView.Value as MonoBehaviour;

            if (mono != null)
            {
                var tween = mono.transform.DOPath(path.Value.ToArray(), _configuration.TimeForBalloonsBalance, PathType.CatmullRom);
                var entity = path.Key;

                tween.onUpdate += () =>
                {
                    entity.ReplacePosition(mono.transform.position);
                };
            }
        }
    }
}