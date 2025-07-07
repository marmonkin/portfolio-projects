using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private GameObject startingRoom;
    [SerializeField] private float moveDuration;

    private List<Room> everySingleRoom = new List<Room>();
    private Room currentRoom;

    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRoom = startingRoom.GetComponent<Room>();
        currentRoom.gameObject.SetActive(true);
        startingRoom.transform.DOLocalMoveY(0, 1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(Room room)
    {
        //currentRoom.gameObject.SetActive(false);
        currentRoom.transform.DOLocalMoveY(-20, 1);
        currentRoom = room;
        currentRoom.transform.DOLocalMoveY(0, 1, true);
        //currentRoom.gameObject.SetActive(true);

        isMoving = true;

        Vector3 _startPosition = cameraPivot.transform.position;
        Vector3 _endPosition = room.MiddlePoint.transform.position;

        cameraPivot.transform.DOMove(_endPosition, moveDuration, true);

        //cameraPivot.transform.position = Vector3.MoveTowards(_startPosition, _endPosition, moveDuration);

        isMoving = false;
    }
}
