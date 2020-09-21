using Entitas;
using UnityEngine;

public class Cleanup2DTriggersSystem : ICleanupSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _triggers;

    public Cleanup2DTriggersSystem(Contexts contexts)
    {
        _contexts = contexts;
        _triggers = _contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.TriggerEnter2D, GameMatcher.TriggerExit2D));
    }

    public void Cleanup()
    {
        foreach (var trigger in _triggers.GetEntities())
        {
            //if (trigger.hasTriggerEnter2D) trigger.RemoveTriggerEnter2D();

            //if (trigger.hasTriggerExit2D) trigger.RemoveTriggerExit2D();
        }
    }
}