using UnityEngine;

public class InteractableTemplate : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Clicked " + this);
    }

    private void OnEnable()
    {
        InteractablesManager.AddInterEvent.Invoke(transform);
    }

    private void OnDisable()
    {
        InteractablesManager.RemoveInterEvent.Invoke(transform);
    }
}
