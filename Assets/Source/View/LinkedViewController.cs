using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class LinkedViewController : MonoBehaviour, IUnityTransform, IPositionListener, IRotationListener,
    IScaleListener, IDestroyedListener, ILayerListener, ITagListener
{
    public IEntity LinkedEntity { get; private set; }
    public Action<GameEntity> OnViewLinked { get; set; }

    public virtual Vector3 Position
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }

    public virtual Quaternion Rotation
    {
        get => transform.localRotation;
        set => transform.localRotation = value;
    }

    public virtual Vector3 Scale
    {
        get => transform.localScale;
        set => transform.localScale = value;
    }


    public void Link(IEntity entity)
    {
        gameObject.Link(entity);
        LinkedEntity = entity;

        var gameEntity = (GameEntity) LinkedEntity;

        HandleListeners(gameEntity);
        gameEntity.AddLinkedView(this);

        HandlePosition(gameEntity);
        HandleScale(gameEntity);
        HandleRotation(gameEntity);
        HandleLayer(gameEntity);
        HandleTag(gameEntity);

        OnViewLinked?.Invoke(gameEntity);
    }

    private void HandleListeners(GameEntity gameEntity)
    {
        gameEntity.AddDestroyedListener(this);
        gameEntity.AddPositionListener(this);
        gameEntity.AddRotationListener(this);
        gameEntity.AddScaleListener(this);
        gameEntity.AddLayerListener(this);
        gameEntity.AddTagListener(this);
    }

    private void HandleTag(GameEntity gameEntity)
    {
        if (gameEntity.hasTag)
        {
            gameObject.tag = gameEntity.tag.Value;
        }
        else
        {
            gameEntity.AddTag(gameObject.tag);
        }
    }

    private void HandleLayer(GameEntity gameEntity)
    {
        if (gameEntity.hasLayer)
        {
            gameObject.layer = gameEntity.layer.Value;
        }
        else
        {
            gameEntity.AddLayer(gameObject.layer);
        }
    }

    private void HandleRotation(GameEntity gameEntity)
    {
        if (gameEntity.hasRotation)
        {
            transform.rotation = gameEntity.rotation.Value;
        }
        else
        {
            gameEntity.AddRotation(transform.localRotation);
        }
    }

    private void HandleScale(GameEntity gameEntity)
    {
        if (gameEntity.hasScale)
        {
            transform.localScale = gameEntity.scale.Value;
        }
        else
        {
            gameEntity.AddScale(transform.localScale);
        }
    }

    private void HandlePosition(GameEntity gameEntity)
    {
        if (gameEntity.hasPosition)
        {
            transform.localPosition = gameEntity.position.Value;
        }
        else
        {
            gameEntity.AddPosition(transform.localPosition);
        }
    }

    public void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = value;
    }

    public void OnRotation(GameEntity entity, Quaternion value)
    {
        transform.localRotation = value;
    }

    public void OnScale(GameEntity entity, Vector3 value)
    {
        transform.localScale = value;
    }

    public void OnDestroyed(GameEntity entity)
    {
        gameObject.Unlink();

        LinkedEntity.Destroy();
        Destroy(gameObject);
    }

    public void OnLayer(GameEntity entity, int value)
    {
        gameObject.layer = value;
    }

    public void OnTag(GameEntity entity, string value)
    {
        gameObject.tag = value;
    }
}