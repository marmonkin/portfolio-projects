using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float stepAngle = 90f;
    [SerializeField] private float rotationSpeed = 180f;

    private bool isRotating = false;
    private Quaternion initialRotation;
    private float currentRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentRotation -= stepAngle;
            ApplyRotation();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentRotation += stepAngle;
            ApplyRotation();
        }
    }

    void ApplyRotation()
    {
        Quaternion newRotation = Quaternion.Euler(0f, currentRotation, 0f);
        transform.rotation = initialRotation * newRotation;
    }
}