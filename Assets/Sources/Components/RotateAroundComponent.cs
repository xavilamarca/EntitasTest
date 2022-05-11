using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundComponent : IComponent
{
    public Vector3 pivot;
    public float Speed;
    public Vector3 axis;
    public float targetAngle;
    public float currentAngle;
}
