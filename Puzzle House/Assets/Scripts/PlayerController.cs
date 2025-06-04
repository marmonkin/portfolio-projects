using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private Transform cam;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float _horInput = Input.GetAxisRaw("Horizontal") * Speed;
        float _vertInput = Input.GetAxisRaw("Vertical") * Speed;

        rb.linearVelocity = new Vector3(_horInput, rb.linearVelocity.y , _vertInput);

        transform.forward = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }
}
