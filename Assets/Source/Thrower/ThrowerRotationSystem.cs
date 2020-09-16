using Entitas;
using UnityEngine;

public class ThrowerRotationSystem : IExecuteSystem
{
    private Contexts _contexts;
    private readonly IGroup<GameEntity> _throwers;

    public ThrowerRotationSystem(Contexts contexts)
    {
        _contexts = contexts;

        // throwers
        _throwers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Thrower, GameMatcher.Movable));
    }

    public void Execute()
    {
        foreach (var thrower in _throwers)
        {
            var angle = Vector3.Angle(thrower.direction.Value, Vector3.right) - 90;
            thrower.ReplaceRotation(Quaternion.AngleAxis(angle, Vector3.forward));
        }
    }
}