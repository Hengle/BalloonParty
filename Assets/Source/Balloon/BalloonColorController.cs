using UnityEngine;

[RequireComponent(typeof(LinkedViewController))]
public class BalloonColorController : MonoBehaviour, IBalloonColorListener
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _shadowRenderer;
    [SerializeField] private float _shadowAlpha;

    private LinkedViewController _linkedView;

    private void Awake()
    {
        _linkedView = GetComponent<LinkedViewController>();
        _linkedView.OnViewLinked += OnViewLinked;
    }

    private void OnViewLinked(GameEntity gameEntity)
    {
        gameEntity.AddBalloonColorListener(this);
        OnBalloonColor(gameEntity, gameEntity.balloonColor.Value);
    }

    public void OnBalloonColor(GameEntity entity, Color value)
    {
        if (_renderer != null)
        {
            _renderer.color = value;
        }

        if (_shadowRenderer != null)
        {
            _shadowRenderer.color = new Color(value.r, value.g, value.b, _shadowAlpha);
        }
    }
}