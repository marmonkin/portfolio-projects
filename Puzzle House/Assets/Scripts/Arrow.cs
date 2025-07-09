using UnityEngine;

public class Arrow : MonoBehaviour
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

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        gManager.GoToRoom(AttachedRoom);
    }
}