using Entitas;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraEntityLinker : EntityLinkerController
{
    protected override void DefineEntity(IEntity e)
    {
        base.DefineEntity(e);

        if (e is GameEntity gameEntity)
        {
            gameEntity.AddCamera(GetComponent<Camera>());
        }
    }
}