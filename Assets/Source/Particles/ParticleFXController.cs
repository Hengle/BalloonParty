using System.Collections.Generic;
using UnityEngine;

public class ParticleFXController : MonoBehaviour, IAnyPlayParticleFXListener
{
    [SerializeField] private List<ParticleSystem> _particleSystems;
    private GameEntity _listener;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        _listener = contexts.game.CreateEntity();
        _listener.AddAnyPlayParticleFXListener(this);
    }

    public void OnAnyPlayParticleFX(GameEntity entity, string value)
    {
        var indexOf = _particleSystems.FindIndex(x => x.name == value);

        if (indexOf >= 0)
        {
            var position = entity.hasPosition ? entity.position.Value : Vector3.zero;
            var rotation = entity.hasRotation ? entity.rotation.Value : Quaternion.identity;
            ParticleSystem ps = null;

            if (!entity.hasParticleFXParent)
            {
                ps = Instantiate(_particleSystems[indexOf], position, rotation, transform);
            }
            else
            {
                var parent = entity.particleFXParent.Value as MonoBehaviour;

                if (parent != null)
                {
                    ps = Instantiate(_particleSystems[indexOf], parent.transform, false);
                }
            }

            if (ps != null)
            {
                ParticleSystem.MainModule main = ps.main;

                if (entity.hasParticleFXStartColor)
                {
                    main.startColor = entity.particleFXStartColor.Value;
                }
            }
        }
    }
}