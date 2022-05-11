//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class EntityPositionEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IEntityPositionListener> _listenerBuffer;

    public EntityPositionEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IEntityPositionListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.EntityPosition)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasEntityPosition && entity.hasEntityPositionListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.entityPosition;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.entityPositionListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnEntityPosition(e, component.Value);
            }
        }
    }
}
