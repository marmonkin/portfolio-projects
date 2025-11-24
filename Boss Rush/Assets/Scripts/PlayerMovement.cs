using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = (moveInput * MovementSpeed);
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = worldMousePos - new Vector2(transform.position.x, transform.position.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

}
