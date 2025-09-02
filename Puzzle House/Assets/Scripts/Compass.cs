using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Vector3 dir;

    private void Update()
    {
        dir.z = cameraTransform.eulerAngles.y;
        transform.localEulerAngles = dir;
    }
}
