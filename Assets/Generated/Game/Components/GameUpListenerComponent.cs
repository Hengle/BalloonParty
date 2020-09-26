//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UpListenerComponent upListener { get { return (UpListenerComponent)GetComponent(GameComponentsLookup.UpListener); } }
    public bool hasUpListener { get { return HasComponent(GameComponentsLookup.UpListener); } }

    public void AddUpListener(System.Collections.Generic.List<IUpListener> newValue) {
        var index = GameComponentsLookup.UpListener;
        var component = (UpListenerComponent)CreateComponent(index, typeof(UpListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUpListener(System.Collections.Generic.List<IUpListener> newValue) {
        var index = GameComponentsLookup.UpListener;
        var component = (UpListenerComponent)CreateComponent(index, typeof(UpListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUpListener() {
        RemoveComponent(GameComponentsLookup.UpListener);
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

    static Entitas.IMatcher<GameEntity> _matcherUpListener;

    public static Entitas.IMatcher<GameEntity> UpListener {
        get {
            if (_matcherUpListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UpListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUpListener = matcher;
            }

            return _matcherUpListener;
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

    public void AddUpListener(IUpListener value) {
        var listeners = hasUpListener
            ? upListener.value
            : new System.Collections.Generic.List<IUpListener>();
        listeners.Add(value);
        ReplaceUpListener(listeners);
    }

    public void RemoveUpListener(IUpListener value, bool removeComponentWhenEmpty = true) {
        var listeners = upListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveUpListener();
        } else {
            ReplaceUpListener(listeners);
        }
    }
}