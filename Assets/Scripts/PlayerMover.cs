using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] PlayerInput input;
    InputAction moveAction;

    void Start()
    {
        moveAction = input.actions["Move"];
    }

    void Update()
    {
        Vector3 direction = moveAction.ReadValue<Vector2>();
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
