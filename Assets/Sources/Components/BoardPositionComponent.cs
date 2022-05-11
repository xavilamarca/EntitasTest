using Entitas;
using UnityEngine;

public class BoardPositionComponent : IComponent
{
    public Vector2 Value;

    public int GetId()
    {
        return Mathf.RoundToInt(Value.x * 100 + Value.y);
    }
}