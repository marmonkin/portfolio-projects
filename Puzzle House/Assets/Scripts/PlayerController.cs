using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private Transform cam;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindFirstObjectByType<Camera>().transform;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float _horInput = Input.GetAxisRaw("Horizontal");
        float _vertInput = Input.GetAxisRaw("Vertical");

        Vector3 _camForward = cam.forward;
        Vector3 _camRight = cam.right;

        _camForward.y = 0;
        _camRight.y = 0;

        Vector3 _forwardRelative = _vertInput * _camForward;
        Vector3 _rightRelative = _horInput * _camRight;

        Vector3 _moveDir = _forwardRelative + _rightRelative;

        rb.linearVelocity = (_moveDir * Time.deltaTime).normalized * Speed;

        transform.forward = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }
}