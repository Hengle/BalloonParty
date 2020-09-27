using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

/// <summary>
/// Adds new slot instances to the indexer entity
/// </summary>
public class SloIndexerSystem : ReactiveSystem<GameEntity>, IDestroyedListener
{
    readonly Contexts _contexts;

    private GameEntity _indexerEntity;

    public SloIndexerSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;

        // create indexer
        _indexerEntity = _contexts.game.CreateEntity();
        _indexerEntity.AddSlotsIndexer(new IEntity[7, 7]);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SlotIndex);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSlotIndex;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            var val = gameEntity.slotIndex.Value;
            _indexerEntity.slotsIndexer.Value[val.x, val.y] = gameEntity;

            // in case its destroyed
            gameEntity.AddDestroyedListener(this);
        }
    }

    /// <summary>
    /// Cleans up the indexer reference when the entity is destroyed
    /// </summary>
    /// <param name="entity"></param>
    public void OnDestroyed(GameEntity entity)
    {
        
    }
}