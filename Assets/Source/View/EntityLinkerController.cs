//using Entitas;

//public class EntityLinkerController : LinkedViewController
//{
//    protected Contexts _contexts;

//    private void Start()
//    {
//        _contexts = Contexts.sharedInstance;
//        var e = _contexts.game.CreateEntity();

//        DefineEntity(e);
//        Link(e);
//    }

//    protected virtual void DefineEntity(IEntity e)
//    {
//        if (!(e is GameEntity)) return;

//        var gameEntity = (GameEntity) e;

//        gameEntity.AddPosition(transform.localPosition);
//        gameEntity.AddRotation(transform.localRotation);
//        gameEntity.AddScale(transform.localScale);
//        gameEntity.AddLayer(gameObject.layer);
//        gameEntity.AddTag(gameObject.tag);
//    }
//}