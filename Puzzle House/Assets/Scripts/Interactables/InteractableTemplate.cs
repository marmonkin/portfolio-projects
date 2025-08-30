using UnityEngine;

public class InteractableTemplate : MonoBehaviour, IInteractable
{
    private GameManager gManager;

    private void OnEnable()
    {
        gManager = FindAnyObjectByType<GameManager>();
    }

    public void OnClickAction()
    {

            Debug.Log("Clicked " + this);
    }
}