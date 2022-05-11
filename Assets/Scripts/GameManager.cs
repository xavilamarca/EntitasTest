using Entitas;
using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _playerViewPrefab;

    Systems _systems;

    // Start is called before the first frame update
    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        CreateSlice(contexts, Vector2.zero, Vector3.zero);
        CreateSlice(contexts, Vector2.right, Vector3.right);
        CreateSlice(contexts, Vector2.right * 2, Vector3.right * 2);
        CreateSlice(contexts, Vector2.up, Vector3.forward);

        _systems = CreateSystems(contexts);
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
    }

    void CreateSlice(Contexts contexts, Vector2 boardPosition, Vector3 position)
    {
        var playerView = Object.Instantiate(_playerViewPrefab);
        var e = contexts.game.CreateEntity();

        var eTransform = playerView.transform;
        eTransform.position = position;
        eTransform.rotation = Quaternion.identity;

        e.AddUnityView(playerView.GetComponent<SliceView>());
        e.AddBoardPosition(boardPosition);
        e.AddEntityPosition(position);
        e.AddRotation(Quaternion.identity);
        e.isSlice = true;

        SliceView sliceComponent = playerView.GetComponent<SliceView>();
        sliceComponent.Link(contexts, e);
    }

    Systems CreateSystems(Contexts contexts)
    {

        // order is respected
        return new Feature("Systems")

            // Input executes first
            .Add(new BoardLogicSystem(contexts))
            // Update 
            .Add(new EntityPositionEventSystem(contexts))
            .Add(new MoveToSystem(contexts))
            .Add(new RotateToSystem(contexts))
            .Add(new RotateAroundSystem(contexts))
            .Add(new RotationEventSystem(contexts));
    }
}
