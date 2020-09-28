//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BalloonColorListenerComponent balloonColorListener { get { return (BalloonColorListenerComponent)GetComponent(GameComponentsLookup.BalloonColorListener); } }
    public bool hasBalloonColorListener { get { return HasComponent(GameComponentsLookup.BalloonColorListener); } }

    public void AddBalloonColorListener(System.Collections.Generic.List<IBalloonColorListener> newValue) {
        var index = GameComponentsLookup.BalloonColorListener;
        var component = (BalloonColorListenerComponent)CreateComponent(index, typeof(BalloonColorListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBalloonColorListener(System.Collections.Generic.List<IBalloonColorListener> newValue) {
        var index = GameComponentsLookup.BalloonColorListener;
        var component = (BalloonColorListenerComponent)CreateComponent(index, typeof(BalloonColorListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBalloonColorListener() {
        RemoveComponent(GameComponentsLookup.BalloonColorListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBalloonColorListener;

    public static Entitas.IMatcher<GameEntity> BalloonColorListener {
        get {
            if (_matcherBalloonColorListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BalloonColorListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBalloonColorListener = matcher;
            }

            return _matcherBalloonColorListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddBalloonColorListener(IBalloonColorListener value) {
        var listeners = hasBalloonColorListener
            ? balloonColorListener.value
            : new System.Collections.Generic.List<IBalloonColorListener>();
        listeners.Add(value);
        ReplaceBalloonColorListener(listeners);
    }

    public void RemoveBalloonColorListener(IBalloonColorListener value, bool removeComponentWhenEmpty = true) {
        var listeners = balloonColorListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveBalloonColorListener();
        } else {
            ReplaceBalloonColorListener(listeners);
        }
    }
}
