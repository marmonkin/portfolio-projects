using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
