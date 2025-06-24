using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject StartingRoom;


    private List<Room> EverySingleRoom = new List<Room>();
    private Room CurrentRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentRoom = StartingRoom.GetComponent<Room>();
        CurrentRoom.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(Room room)
    {
        CurrentRoom.gameObject.SetActive(false);
        CurrentRoom = room;
        CurrentRoom.gameObject.SetActive(true);
        Camera.transform.position = room.MiddlePoint.transform.position;
    }
}
