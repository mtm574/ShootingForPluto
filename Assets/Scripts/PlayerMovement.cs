using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 5f;
    Vector2 moveInput;

    // Called automatically by PlayerInput component
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        transform.Translate(moveInput * speed * Time.deltaTime);
    }
}
