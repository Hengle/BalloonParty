using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameStartedBalloonsSpawnSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;

    public GameStartedBalloonsSpawnSystem(Contexts contexts) : base(contexts.game)
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
        var coroutineRunner = _contexts.game.coroutineRunner.Value;
        coroutineRunner.StartCoroutine(InstanceBalloonLines());
    }

    private IEnumerator InstanceBalloonLines()
    {
        for (int i = 0; i < _configuration.GameStartedBalloonLines; i++)
        {
            var e = _contexts.game.CreateEntity();
            e.isBalloonLineInstanceEvent = true;
            yield return new WaitForSeconds(_configuration.GameStartedBalloonLinesTimeInterval);
        }
    }
}