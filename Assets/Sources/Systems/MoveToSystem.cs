using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveToSystem : IExecuteSystem
{
    readonly Contexts _context;

    public MoveToSystem(Contexts contexts)
    {
        _context = contexts;
    }

    public void Execute()
    {
        var entities = _context.game.GetEntities(GameMatcher.MoveTo);

        var toRemove = new List<GameEntity>();

        foreach (var e in entities)
        {
            MoveToComponent moveTo = e.moveTo;

            Vector3 currentPos = e.entityPosition.Value;

            currentPos = Vector3.MoveTowards(currentPos, moveTo.Value, Time.deltaTime * moveTo.Speed);

            e.ReplaceEntityPosition(currentPos);

            if (currentPos == moveTo.Value)
            {
                toRemove.Add(e);
            }
        }

        foreach (var e in toRemove)
        {
            e.RemoveMoveTo();
        }
    }
}