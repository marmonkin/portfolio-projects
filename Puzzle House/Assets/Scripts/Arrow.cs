using UnityEngine;

public class Arrow : MonoBehaviour,IInteractable
{
    public Room AttachedRoom;

    private Room parentRoom;
    private GameManager gManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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