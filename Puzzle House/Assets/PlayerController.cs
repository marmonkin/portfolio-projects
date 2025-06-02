using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private float TurnSpeed = 360;
    
    private Rigidbody rb;
    private Transform model;
    private Vector3 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        model = rb.GetComponent<Transform>();
    }

    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        model.rotation = Quaternion.RotateTowards(model.rotation, rot, TurnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        rb.MovePosition(transform.position + input.ToIso() * input.normalized.magnitude * Speed * Time.deltaTime);
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
