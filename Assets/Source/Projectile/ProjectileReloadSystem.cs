using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class ProjectileReloadSystem : ReactiveSystem<GameEntity>, ILinkedViewListener
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
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ReadyToLoad, GameMatcher.Thrower));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isThrower && entity.isReadyToLoad;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var e = _contexts.game.CreateEntity();

        e.AddAsset("Projectile");
        e.isProjectile = true;
        e.isLoadedProjectile = true;

        // initial position
        e.AddScale(Vector3.zero);
        e.AddPosition(_configuration.ProjectileSpawnPoint);
        e.AddLinkedViewListener(this);
    }

    public void OnLinkedView(GameEntity entity, ILinkedView value)
    {
        var mono = value as MonoBehaviour;

        // find thrower
        var thrower = _contexts.game.throwerEntity;

        if (mono != null)
        {
            var tween = mono.transform.DOScale(Vector3.one, 1f);
            thrower.isReadyToLoad = false;

            tween.onUpdate += () => { entity.ReplaceScale(mono.transform.localScale); };

            tween.onComplete += () =>
            {
                thrower.isReadyToThrow = true;
                thrower.ReplaceThrowerLoadedProjectile(entity);
            };
        }

        entity.RemoveLinkedViewListener(this);
    }
}