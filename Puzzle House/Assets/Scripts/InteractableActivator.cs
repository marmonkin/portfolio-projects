using UnityEngine;

public class InteractableActivator : MonoBehaviour
{
    private void OnEnable()
    {
        InteractablesManager.AddInterEvent.Invoke(transform);
    }

    private void OnDisable()
    {
        InteractablesManager.RemoveInterEvent.Invoke(transform);
    }
}
