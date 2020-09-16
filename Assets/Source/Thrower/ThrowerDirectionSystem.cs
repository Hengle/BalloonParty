using Entitas;
using UnityEngine;

public class ThrowerDirectionSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _throwers;
    private readonly IGroup<GameEntity> _cameras;

    public ThrowerDirectionSystem(Contexts contexts)
    {
        _contexts = contexts;
        _throwers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Thrower, GameMatcher.Movable));
        _cameras = _contexts.game.GetGroup(GameMatcher.Camera);
    }

    public void Execute()
    {
        var mousePos = Input.mousePosition;

        if (_cameras.count <= 0) return;

        foreach (var entity in _cameras)
        {
            var camera = entity.camera.Value;

            foreach (var thrower in _throwers)
            {
                var pos = thrower.position.Value;
                var screenPos = camera.WorldToScreenPoint(pos);
                var direction = (mousePos - screenPos).normalized;

                thrower.ReplaceDirection(direction);
#if UNITY_EDITOR
                Debug.DrawRay(pos, direction, Color.magenta);
#endif
            }

            break;
        }
    }
}