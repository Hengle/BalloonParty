using Entitas;
using UnityEngine;

public class ThrowerRotationSystem : IExecuteSystem
{
    private Contexts _contexts;
    private readonly IGroup<GameEntity> _throwers;
    private readonly IGroup<GameEntity> _cameras;

    public ThrowerRotationSystem(Contexts contexts)
    {
        _contexts = contexts;

        // throwers
        _throwers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Thrower, GameMatcher.ReadyToThrow));
        _cameras = _contexts.game.GetGroup(GameMatcher.Camera);
    }

    public void Execute()
    {
        var mousePos = Input.mousePosition;

        if (_cameras.count <= 0) return;

        foreach (var entity in _cameras)
        {
            var camera = (entity.linkedView.Value as MonoBehaviour)?.GetComponent<Camera>();

            if (camera == null) return;

            foreach (var thrower in _throwers)
            {
                var angle = Vector3.Angle(thrower.direction.Value, Vector3.right) - 90;
                thrower.ReplaceRotation(Quaternion.AngleAxis(angle, Vector3.forward));
            }

            break;
        }
    }
}