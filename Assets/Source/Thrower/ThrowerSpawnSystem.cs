using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ThrowerSpawnSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public ThrowerSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
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
    }
}
