using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(LinkedViewController))]
public class ProjectileGlowColorController : MonoBehaviour, IBalloonColorListener
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField, Range(0f, 1f)] private float _alpha;
    [SerializeField] private float _colorDuration;

    private LinkedViewController _linkedView;

    private void Awake()
    {
        _linkedView = GetComponent<LinkedViewController>();
        _linkedView.OnViewLinked += OnViewLinked;
    }

    private void OnViewLinked(GameEntity gameEntity)
    {
        gameEntity.AddBalloonColorListener(this);
    }

    public void OnBalloonColor(GameEntity entity, Color value)
    {
        if (_renderer != null)
        {
            var targetColor = new Color(value.r, value.g, value.b, _alpha);
            _renderer.DOColor(targetColor, _colorDuration);
        }
    }
}