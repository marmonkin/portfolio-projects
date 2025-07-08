using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private GameObject startingRoom;
    [SerializeField] private float moveDuration;
    [SerializeField] private Ease roomEaseType;
    [SerializeField] private Ease camEaseType;

    private List<Room> everySingleRoom = new List<Room>();
    private Room currentRoom;
    private Room previousRoom;

    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRoom = startingRoom.GetComponent<Room>();
        startingRoom.transform.DOLocalMoveY(0, 1).SetEase(roomEaseType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToRoom(Room room)
    {
        //currentRoom.gameObject.SetActive(false);
        currentRoom.transform.DOLocalMoveY(-30, 1).SetEase(roomEaseType);
        previousRoom = currentRoom;
        Invoke("HideRoom", 1);

        currentRoom = room;
        currentRoom.gameObject.SetActive(true);
        currentRoom.transform.DOLocalMoveY(0, 1).SetEase(roomEaseType);
        //currentRoom.gameObject.SetActive(true);

        isMoving = true;

        Vector3 _startPosition = cameraPivot.transform.position;
        Vector3 _endPosition = room.MiddlePoint.transform.position;

        cameraPivot.transform.DOMove(_endPosition, moveDuration).SetEase(camEaseType);

        //cameraPivot.transform.position = Vector3.MoveTowards(_startPosition, _endPosition, moveDuration);

        isMoving = false;
    }

    private void HideRoom()
    {
        previousRoom.gameObject.SetActive(false);
    }
}
