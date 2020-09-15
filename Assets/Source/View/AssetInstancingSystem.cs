using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// This class instantiates objects with asset and links their view components.
/// USes the <see cref="Resources"/> folder.
/// </summary>
public class AssetInstancingSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    /// <summary>
    /// All instaces will be set as children of this transform
    /// </summary>
    private readonly Transform _parent;

    public AssetInstancingSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Asset));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasLinkedView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var gameEntity in entities)
        {
            var prefab = Resources.Load<GameObject>(gameEntity.asset.Value);
            var view = Object.Instantiate(prefab, _parent).GetComponent<ILinkedView>();

            if (view != null)
            {
                view.Link(gameEntity);
            }
            else
            {
                Debug.LogWarning("Trying to instantiate asset without a LinkedView component");
            }
        }
    }
}