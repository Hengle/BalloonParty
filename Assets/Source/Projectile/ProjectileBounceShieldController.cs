using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LinkedViewController))]
public class ProjectileBounceShieldController : MonoBehaviour, IProjectileBounceShieldListener
{
    [SerializeField] private List<GameObject> _shields;

    private LinkedViewController _linkedView;

    private void Awake()
    {
        _linkedView = GetComponent<LinkedViewController>();

        _linkedView.OnViewLinked += OnViewLinked;
    }

    private void OnViewLinked(GameEntity gameEntity)
    {
        gameEntity.AddProjectileBounceShieldListener(this);
    }

    public void OnProjectileBounceShield(GameEntity entity, int value)
    {
        for (var i = 0; i < _shields.Count; i++)
        {
            _shields[i].gameObject.SetActive(i < value);
        }
    }
}