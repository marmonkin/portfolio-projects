using UnityEngine;

public class InteractableTemplate : MonoBehaviour, IInteractable
{
    public bool DoNotRespawn { get; set; }
    public bool NoRespawn;

    private GameManager gManager;

    private void OnEnable()
    {
        gManager = FindAnyObjectByType<GameManager>();
        //DoNotRespawn = NoRespawn;
    }

    public void OnClickAction()
    {

            Debug.Log("Clicked " + this);
    }
}