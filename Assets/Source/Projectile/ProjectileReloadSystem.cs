using System.Collections.Generic;
using Entitas;

public class ProjectileReloadSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IGameConfiguration _configuration;

    public ProjectileReloadSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _configuration = _contexts.configuration.gameConfiguration.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}