using UnityEngine;

public class I_DoorCollectable : MonoBehaviour, IInteractable
{
    public bool DoNotRespawn { get; set; }
    public bool NoRespawn;

    private GameManager gManager;

    public bool Collected;

    private void OnEnable()
    {
        gManager = FindAnyObjectByType<GameManager>();
        
        Collected = false;
    }

    public void OnClickAction()
    {
        Collected = true;
        this.gameObject.SetActive(false);
        DoNotRespawn = NoRespawn;
    }
}
