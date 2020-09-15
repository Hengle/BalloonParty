using Entitas;

public class CameraEntityLinker : EntityLinkerController
{
    protected override void DefineEntity(IEntity e)
    {
        base.DefineEntity(e);

        if (e is GameEntity gameEntity)
        {
            gameEntity.isCamera = true;
        }
    }
}