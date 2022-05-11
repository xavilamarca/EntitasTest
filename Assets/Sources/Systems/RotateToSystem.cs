using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RotateToSystem : IExecuteSystem
{
    readonly Contexts _context;

    public RotateToSystem(Contexts contexts)
    {
        _context = contexts;
    }

    public void Execute()
    {
        var entities = _context.game.GetEntities(GameMatcher.RotateTo);

        var toRemove = new List<GameEntity>();

        foreach (var e in entities)
        {
            RotateToComponent rotateTo = e.rotateTo;

            var currentRotation = e.rotation.Value;

            currentRotation = Quaternion.RotateTowards(currentRotation, rotateTo.Value, Time.deltaTime * rotateTo.Speed);

            e.ReplaceRotation(currentRotation);

            if (currentRotation == rotateTo.Value)
            {
                toRemove.Add(e);
            }
        }

        foreach (var e in toRemove)
        {
            e.RemoveRotateTo();
        }
    }
}