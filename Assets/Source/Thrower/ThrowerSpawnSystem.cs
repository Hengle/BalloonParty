using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class ThrowerSpawnSystem : ReactiveSystem<GameEntity>, ILinkedViewListener
{
    private readonly Contexts _contexts;
    private IGameConfiguration _configuration;

    public ThrowerSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.GameEvent, GameMatcher.GameStarted));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameEvent && entity.isGameStarted;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var e = _contexts.game.CreateEntity();

        e.AddAsset("Thrower");
        e.isThrower = true;

        // initial position
        e.AddPosition(_configuration.ThrowerSpawnPoint + Vector2.down);
        e.AddLinkedViewListener(this);
    }

    public void OnLinkedView(GameEntity entity, ILinkedView value)
    {
        var mono = value as MonoBehaviour;

        if (mono != null)
        {
            mono.transform.DOMove(_configuration.ThrowerSpawnPoint, 1f);
        }
    }
}
