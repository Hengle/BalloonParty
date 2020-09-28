using Entitas;

public class CoroutineRunnerController : EntityLinkerController
{
    protected override void DefineEntity(IEntity e)
    {
        base.DefineEntity(e);

        var gameEntity = e as GameEntity;
        gameEntity?.AddCoroutineRunner(this);
    }
}