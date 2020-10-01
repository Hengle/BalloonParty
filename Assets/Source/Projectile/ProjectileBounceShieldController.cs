using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(LinkedViewController))]
public class ProjectileBounceShieldController : MonoBehaviour, IProjectileBounceShieldListener, IBalloonColorListener
{
    [SerializeField] private List<SpriteRenderer> _shields;
    [SerializeField, Range(0f, 1f)] private float _alpha;
    [SerializeField] private float _colorDuration;

    [Header("Shields Scaling")] [SerializeField]
    private float _scaleDuration;

    [SerializeField] private Vector2 _increments;

    private LinkedViewController _linkedView;

    private void Awake()
    {
        _linkedView = GetComponent<LinkedViewController>();

        _linkedView.OnViewLinked += OnViewLinked;

        for (var i = 0; i < _shields.Count; i++)
        {
            _shields[i].transform.localScale = Vector3.zero;
        }
    }

    private void OnViewLinked(GameEntity gameEntity)
    {
        gameEntity.AddProjectileBounceShieldListener(this);
        gameEntity.AddBalloonColorListener(this);
    }

    public void OnProjectileBounceShield(GameEntity entity, int value)
    {
        for (var i = 0; i < _shields.Count; i++)
        {
            _shields[i].transform
                .DOScale(i < value
                    ? Vector3.one + Vector3.right * _increments.x * i + Vector3.up * _increments.y * i
                    : Vector3.zero, _scaleDuration);
        }
    }

    public void OnBalloonColor(GameEntity entity, Color value)
    {
        var targetColor = new Color(value.r, value.g, value.b, _alpha);

        foreach (var t in _shields)
        {
            if (t != null)
            {
                t.DOColor(targetColor, _colorDuration);
            }
        }
    }
}