using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private GameObject startingRoom;


    private List<Room> everySingleRoom = new List<Room>();
    private Room currentRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRoom = startingRoom.GetComponent<Room>();
        currentRoom.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(Room room)
    {
        currentRoom.gameObject.SetActive(false);
        currentRoom = room;
        currentRoom.gameObject.SetActive(true);
        cameraPivot.transform.position = room.MiddlePoint.transform.position;
    }
}
