//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new BalloonColorEventSystem(contexts)); // priority: 0
        Add(new BalloonLastColorPopCountEventSystem(contexts)); // priority: 0
        Add(new AnyBalloonLineInstanceEventEventSystem(contexts)); // priority: 0
        Add(new AnyBalloonsBalanceEventEventSystem(contexts)); // priority: 0
        Add(new CameraEventSystem(contexts)); // priority: 0
        Add(new DestroyedEventSystem(contexts)); // priority: 0
        Add(new DirectionEventSystem(contexts)); // priority: 0
        Add(new ForwardEventSystem(contexts)); // priority: 0
        Add(new AnyGameEventEventSystem(contexts)); // priority: 0
        Add(new AnyGameStartedEventSystem(contexts)); // priority: 0
        Add(new LayerEventSystem(contexts)); // priority: 0
        Add(new LinkedViewEventSystem(contexts)); // priority: 0
        Add(new MovableEventSystem(contexts)); // priority: 0
        Add(new MovableRemovedEventSystem(contexts)); // priority: 0
        Add(new AnyPlayParticleFXEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new ProjectileEventSystem(contexts)); // priority: 0
        Add(new ProjectileBounceShieldEventSystem(contexts)); // priority: 0
        Add(new ReadyToLoadEventSystem(contexts)); // priority: 0
        Add(new ReadyToThrowEventSystem(contexts)); // priority: 0
        Add(new RightEventSystem(contexts)); // priority: 0
        Add(new RotationEventSystem(contexts)); // priority: 0
        Add(new ScaleEventSystem(contexts)); // priority: 0
        Add(new SlotIndexEventSystem(contexts)); // priority: 0
        Add(new SpeedEventSystem(contexts)); // priority: 0
        Add(new TagEventSystem(contexts)); // priority: 0
        Add(new ThrowerEventSystem(contexts)); // priority: 0
        Add(new TriggerEnter2DEventSystem(contexts)); // priority: 0
        Add(new TriggerExit2DEventSystem(contexts)); // priority: 0
        Add(new UpEventSystem(contexts)); // priority: 0
    }
}
