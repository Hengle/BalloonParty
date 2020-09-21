using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class LinkedViewController : MonoBehaviour, IUnityTransform, IPositionListener, IRotationListener,
    IScaleListener, IDestroyedListener, ILayerListener, ITagListener, IUpListener, IRightListener, IForwardListener
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

    public Vector3 Up
    {
        get => transform.up;
        set => transform.up = value;
    }

    public Vector3 Right
    {
        get => transform.right;
        set => transform.right = value;
    }

    public Vector3 Forward
    {
        get => transform.forward;
        set => transform.forward = value;
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
        HandleUp(gameEntity);
        HandleRight(gameEntity);
        HandleForward(gameEntity);
        HandleLayer(gameEntity);
        HandleTag(gameEntity);

        OnViewLinked?.Invoke(gameEntity);
    }

    private void HandleListeners(GameEntity gameEntity)
    {
        gameEntity.AddPositionListener(this);
        gameEntity.AddRotationListener(this);
        gameEntity.AddScaleListener(this);

        gameEntity.AddUpListener(this);
        gameEntity.AddRightListener(this);
        gameEntity.AddForwardListener(this);

        gameEntity.AddLayerListener(this);
        gameEntity.AddTagListener(this);
        gameEntity.AddDestroyedListener(this);
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

    private void HandleUp(GameEntity gameEntity)
    {
        if (gameEntity.hasUp)
        {
            transform.up = gameEntity.up.Value;
        }
        else
        {
            gameEntity.AddUp(transform.up);
        }
    }

    private void HandleRight(GameEntity gameEntity)
    {
        if (gameEntity.hasRight)
        {
            transform.right = gameEntity.right.Value;
        }
        else
        {
            gameEntity.AddRight(transform.right);
        }
    }

    private void HandleForward(GameEntity gameEntity)
    {
        if (gameEntity.hasForward)
        {
            transform.forward = gameEntity.forward.Value;
        }
        else
        {
            gameEntity.AddForward(transform.forward);
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

    public void OnUp(GameEntity entity, Vector3 value)
    {
        transform.up = value;
    }

    public void OnRight(GameEntity entity, Vector3 value)
    {
        transform.right = value;
    }

    public void OnForward(GameEntity entity, Vector3 value)
    {
        transform.forward = value;
    }
}