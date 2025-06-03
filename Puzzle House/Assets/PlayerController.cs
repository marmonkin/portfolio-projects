using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float TurnSpeed = 360f;
    [Space(5)]

    [Header("Camera")]
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private float stepAngle = 90f;
    [SerializeField] private float rotationSpeed = 180f;

    private Rigidbody rb;
    private Transform model;
    private Vector3 input;

    private bool isRotating = false;
    private Quaternion targetRotation;
    private Vector3 rotationChange;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        model = rb.GetComponent<Transform>();

        targetRotation = cameraPivot.transform.rotation;
    }

    private void Update()
    {
        GatherInput();
        Look();

        if (Input.GetKeyDown("e"))
        {
            CameraRotate(stepAngle);
        }

        if (Input.GetKeyDown("q"))
        {
            CameraRotate(-stepAngle);
        }
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

    private void CameraRotate(float angle)
    {
        isRotating = true;
        targetRotation.y = cameraPivot.transform.rotation.y + angle;

        while (isRotating)
        {
            cameraPivot.transform.Rotate(cameraPivot.transform.rotation.x, angle * Time.deltaTime, 0, Space.World);

            if (targetRotation == cameraPivot.transform.rotation)
            {
                isRotating = false;
                //cameraPivot.transform.rotation = targetRotation;
            }
        }
    }


}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
