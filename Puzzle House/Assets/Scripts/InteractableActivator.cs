using UnityEngine;

public class InteractableActivator : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Enable", 1);
    }

    private void OnDisable()
    {
        Invoke("Disable", 1);
    }

    private void Enable()
    {
        InteractablesManager.AddInterEvent.Invoke(transform);
    }

    private void Disable()
    {
        InteractablesManager.RemoveInterEvent.Invoke(transform);
    }
}