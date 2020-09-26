using System.Collections.Generic;
using Entitas;

public class BalloonLineSpawnerSystem : ReactiveSystem<GameEntity>
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
            var e = _contexts.game.CreateEntity();
            e.isBalloon = true;

            e.AddAsset("Balloon");
        }
    }
}