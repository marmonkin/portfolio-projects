using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float stepAngle = 90f;
    [SerializeField] private float rotateDuration = 10f;

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
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(ApplyRotation(-stepAngle));
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(ApplyRotation(stepAngle));
        }
    }

    private IEnumerator ApplyRotation(float rotation)
    {
        isRotating = true;

        Quaternion _startRotation = transform.rotation;
        Quaternion _newRotation = Quaternion.Euler(0f, rotation, 0f);
        Quaternion _endRotation = initialRotation * _newRotation;

        float _elapsed = 0f;

        while (_elapsed < rotateDuration)
        {
            transform.rotation = Quaternion.Slerp(_startRotation, _endRotation, _elapsed / rotateDuration);

            _elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = _endRotation;
        initialRotation = transform.rotation;
        isRotating = false;
    }
}