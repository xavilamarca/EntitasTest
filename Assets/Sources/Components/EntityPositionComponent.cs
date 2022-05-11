using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class EntityPositionComponent : IComponent
{
    public Vector3 Value;
}