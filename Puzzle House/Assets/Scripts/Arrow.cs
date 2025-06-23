using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Room attachedRoom;

    private Room ParentRoom;
    private GameManager gManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentRoom = GetComponentInParent<Room>();
        gManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gManager.GoToRoom(attachedRoom);
    }
}
