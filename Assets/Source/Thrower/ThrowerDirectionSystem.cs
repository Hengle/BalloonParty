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

        // throwers
        _throwers = _contexts.game.GetGroup(GameMatcher.Thrower);
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
                var pos = thrower.position.Value;
                var screenPos = camera.WorldToScreenPoint(pos);
                var direction = (mousePos - screenPos).normalized;

                thrower.ReplaceDirection(direction);

                if (thrower.isReadyToThrow)
                {
                    var angle = Vector3.Angle(direction, Vector3.right) - 90;
                    thrower.ReplaceRotation(Quaternion.AngleAxis(angle, Vector3.forward));
                }
#if UNITY_EDITOR
                Debug.DrawRay(pos, direction, Color.magenta);
#endif
            }

            break;
        }
    }
}