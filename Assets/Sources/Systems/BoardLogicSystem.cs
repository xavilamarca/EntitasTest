using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BoardLogicSystem : IExecuteSystem
{
    readonly Contexts _context;

    GameEntity origin;

    Dictionary<int, Stack<GameEntity>> board;

    const float FLOOR_HEIGHT = 0.12f;
    const float MOVE_SPEED = 360;

    public BoardLogicSystem(Contexts contexts)
    {
        _context = contexts;
    }

    public void Execute()
    {
        if (board == null)
        {
            board = new Dictionary<int, Stack<GameEntity>>();

            var slices = _context.game.GetEntities(GameMatcher.Slice);

            foreach (var slice in slices)
            {
                int idx = slice.boardPosition.GetId();

                Stack<GameEntity> s = new Stack<GameEntity>();
                s.Push(slice);
                board.Add(idx, s);
            }
        }

        var clickeds = _context.game.GetEntities(GameMatcher.Clicked);

        var toUnClick = new List<GameEntity>();

        foreach (var clicked in clickeds)
        {
            if (origin == null)
            {
                origin = clicked;
                origin.ReplaceSelected(true);
            }
            else if (origin == clicked)
            {
                origin.ReplaceSelected(false);
                origin = null;
            }
            else
            {
                MoveStacks(origin, clicked);

                origin.ReplaceSelected(false);

                origin = null;
            }

            toUnClick.Add(clicked);
        }

        foreach (var e in toUnClick)
        {
            e.isClicked = false;
        }
    }

    private void MoveStacks(GameEntity origin, GameEntity target)
    {
        var boardOrigin = origin.boardPosition.Value;
        var boardTarget = target.boardPosition.Value;

        int stackOriginIndex = origin.boardPosition.GetId();
        int stackTargetIndex = target.boardPosition.GetId();

        var stackOrigin = board[stackOriginIndex];
        var stackTarget = board[stackTargetIndex];

        Vector3 nextPosition = stackTarget.Peek().entityPosition.Value + Vector3.up * FLOOR_HEIGHT;
        
        while (stackOrigin.Count > 0)
        {
            var e = stackOrigin.Pop();

            e.ReplaceBoardPosition(target.boardPosition.Value);

            Vector3 axis = Vector3.zero;

            if (boardOrigin.x < boardTarget.x)
            {
                axis = Vector3.back;
            }
            else if (boardOrigin.x > boardTarget.x)
            {
                axis = Vector3.forward;
            }
            else if (boardOrigin.y < boardTarget.y)
            {
                axis = Vector3.right;
            }
            else if (boardOrigin.y > boardTarget.y)
            {
                axis = Vector3.left;
            }

            e.AddRotateAround(Vector3.Lerp(e.entityPosition.Value, nextPosition, 0.5f), MOVE_SPEED, axis, 180, 0);

            nextPosition += Vector3.up * FLOOR_HEIGHT;
            stackTarget.Push(e);
        }
    }
}