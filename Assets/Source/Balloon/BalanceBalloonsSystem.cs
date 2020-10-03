using System.Collections.Generic;
using Entitas;
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
        for (int i = 0; i < _slots.GetLength(0); i++)
        {
            for (int j = _slots.GetLength(1) - 1; j >= 0; j--)
            {
                var isEmpty = _slots.IsEmpty(i, j);

                if (!isEmpty)
                {
                    var isUnbalanced = _slots.IsUnbalanced(i, j);

                    if (isUnbalanced)
                    {
                        var balloonEntity = _slots[i, j] as GameEntity;
                        balloonEntity.ReplaceBalloonColor(Color.yellow);
                        Debug.Log(i + ", " + j);
                    }
                }
            }
        }
    }
}