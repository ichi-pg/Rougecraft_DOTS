using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Entities;

public class InputTransfer : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    InputAction moveAction;

    void Start()
    {
        moveAction = input.actions["Move"];
    }

    void Update()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var query = entityManager.CreateEntityQuery(typeof(InputReceiver));
        var entity = query.GetSingletonRW<InputReceiver>();
        entity.ValueRW.MoveDirection = moveAction.ReadValue<Vector2>();
    }
}
