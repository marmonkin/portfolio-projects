using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject StartingRoom;

    private Room CurrentRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentRoom = StartingRoom.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(Room room)
    {
        Camera.transform.position = room.MiddlePoint.transform.position;
        CurrentRoom = room;
    }
}
