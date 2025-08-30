using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot;
    [SerializeField] private GameObject startingRoom;
    [SerializeField] private float cameraMoveDuration;
    [SerializeField] private float roomMoveDuration;
    [SerializeField] private Ease roomEaseType;
    [SerializeField] private Ease camEaseType;

    [Space(10)]
    [Header("Note Stuff")]
    public Canvas NoteCanvas;
    public Image NoteBgImage;
    public TMP_Text NoteText;

    private List<Room> everySingleRoom = new List<Room>();
    private Room currentRoom;
    private Room previousRoom;

    private bool isMoving;

    [HideInInspector] public bool CanInteract = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentRoom = startingRoom.GetComponent<Room>();
        startingRoom.transform.DOLocalMoveY(0, 0);

        CanInteract = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(CanInteract);
    }

    public void GoToRoom(Room room)
    {
        //currentRoom.gameObject.SetActive(false);
        currentRoom.transform.DOLocalMoveY(-30, roomMoveDuration).SetEase(roomEaseType);
        previousRoom = currentRoom;
        Invoke("HideRoom", roomMoveDuration);

        currentRoom = room;

        //currentRoom.gameObject.SetActive(true);
        currentRoom.gameObject.SetActive(true);
        currentRoom.transform.DOLocalMoveY(0, roomMoveDuration).SetEase(roomEaseType);

        isMoving = true;

        Vector3 _startPosition = cameraPivot.transform.position;
        Vector3 _endPosition = room.MiddlePoint.transform.position;

        cameraPivot.transform.DOMove(_endPosition, cameraMoveDuration).SetEase(camEaseType);

        //cameraPivot.transform.position = Vector3.MoveTowards(_startPosition, _endPosition, moveDuration);

        isMoving = false;
    }

    private void HideRoom()
    {
        previousRoom.gameObject.SetActive(false);
    }
}