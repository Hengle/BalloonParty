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
        _indexerEntity.AddSlotIndexer(new Dictionary<Vector2Int, IEntity>());
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SlotIndexingEvent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSlotIndexingEvent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            _indexerEntity.slotIndexer.Value[gameEntity.slotIndexingEvent.Value] = gameEntity;

            // in case its destroyed
            gameEntity.AddDestroyedListener(this);
        }
    }

    public void OnDestroyed(GameEntity entity)
    {
        // clean up indexer
        foreach (var keyValuePair in _indexerEntity.slotIndexer.Value.ToList())
        {
            if (keyValuePair.Value == null || !keyValuePair.Value.isEnabled)
            {
                _indexerEntity.slotIndexer.Value.Remove(keyValuePair.Key);
            }
        }
    }
}