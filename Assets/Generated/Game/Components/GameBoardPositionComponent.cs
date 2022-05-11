//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BoardPositionComponent boardPosition { get { return (BoardPositionComponent)GetComponent(GameComponentsLookup.BoardPosition); } }
    public bool hasBoardPosition { get { return HasComponent(GameComponentsLookup.BoardPosition); } }

    public void AddBoardPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.BoardPosition;
        var component = (BoardPositionComponent)CreateComponent(index, typeof(BoardPositionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBoardPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.BoardPosition;
        var component = (BoardPositionComponent)CreateComponent(index, typeof(BoardPositionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBoardPosition() {
        RemoveComponent(GameComponentsLookup.BoardPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherBoardPosition;

    public static Entitas.IMatcher<GameEntity> BoardPosition {
        get {
            if (_matcherBoardPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BoardPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBoardPosition = matcher;
            }

            return _matcherBoardPosition;
        }
    }
}
