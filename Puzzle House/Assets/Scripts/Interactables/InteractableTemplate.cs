using UnityEngine;

public class InteractableTemplate : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Clicked " + this);
    }

}
