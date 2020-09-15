using Entitas;

/// <summary>
/// This interface represents a link between an Unity layer
/// <see cref="GameObject"/> and a <see cref="GameEntity"/>
/// </summary>
public interface ILinkedView
{
    IEntity LinkedEntity { get; }
    
    void Link(IEntity entity);
}