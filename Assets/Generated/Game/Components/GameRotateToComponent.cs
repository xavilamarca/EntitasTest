//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RotateToComponent rotateTo { get { return (RotateToComponent)GetComponent(GameComponentsLookup.RotateTo); } }
    public bool hasRotateTo { get { return HasComponent(GameComponentsLookup.RotateTo); } }

    public void AddRotateTo(float newSpeed, UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.RotateTo;
        var component = (RotateToComponent)CreateComponent(index, typeof(RotateToComponent));
        component.Speed = newSpeed;
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRotateTo(float newSpeed, UnityEngine.Quaternion newValue) {
        var index = GameComponentsLookup.RotateTo;
        var component = (RotateToComponent)CreateComponent(index, typeof(RotateToComponent));
        component.Speed = newSpeed;
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRotateTo() {
        RemoveComponent(GameComponentsLookup.RotateTo);
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

    static Entitas.IMatcher<GameEntity> _matcherRotateTo;

    public static Entitas.IMatcher<GameEntity> RotateTo {
        get {
            if (_matcherRotateTo == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotateTo);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotateTo = matcher;
            }

            return _matcherRotateTo;
        }
    }
}
