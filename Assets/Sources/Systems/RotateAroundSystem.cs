using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RotateAroundSystem : IExecuteSystem
{
    readonly Contexts _context;

    public RotateAroundSystem(Contexts contexts)
    {
        _context = contexts;
    }

    public void Execute()
    {
        var entities = _context.game.GetEntities(GameMatcher.RotateAround);

        var toRemove = new List<GameEntity>();

        foreach (var e in entities)
        {
            RotateAroundComponent rotateAround = e.rotateAround;

            float inc = rotateAround.Speed * Time.deltaTime;
            float remaning = rotateAround.targetAngle - rotateAround.currentAngle;
            float realInc = Mathf.Min(remaning, inc);

            Quaternion rot = Quaternion.AngleAxis(realInc, rotateAround.axis);
            e.ReplaceEntityPosition(rot * (e.entityPosition.Value - rotateAround.pivot) + rotateAround.pivot);
            e.ReplaceRotation(rot * e.rotation.Value);

            rotateAround.currentAngle += realInc;

            if (rotateAround.currentAngle == rotateAround.targetAngle)
            {
                toRemove.Add(e);
            }
        }

        foreach (var e in toRemove)
        {
            e.RemoveRotateAround();
        }
    }
}