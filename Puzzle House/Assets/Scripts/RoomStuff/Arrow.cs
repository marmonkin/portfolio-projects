using UnityEngine;

public class Arrow : MonoBehaviour, IInteractable
{
    public Room AttachedRoom;

    private Room parentRoom;
    private GameManager gManager;

    private void Start()
    {
        parentRoom = GetComponentInParent<Room>();
        gManager = FindAnyObjectByType<GameManager>();
    }

    public void OnClickAction()
    {
        gManager.GoToRoom(AttachedRoom);
    }
}