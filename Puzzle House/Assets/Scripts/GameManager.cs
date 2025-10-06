using DG.Tweening;
using System;
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
    public GameObject NoteOverlay;
    public Image NoteBgImage;
    public TMP_Text NoteText;

    //private Room currentRoom;
    //private Room previousRoom;

    [HideInInspector] public bool CanInteract = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Level.CurrentRoom = startingRoom.GetComponent<Room>();
        startingRoom.transform.DOLocalMoveY(0, 0);

        CanInteract = true;

        RevealRooms();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(CanInteract);
    }

    public void GoToRoom(Room room)
    {
        //currentRoom.gameObject.SetActive(false);
        Level.CurrentRoom.transform.DOLocalMoveY(-30, roomMoveDuration).SetEase(roomEaseType);
        Level.PreviousRoom = Level.CurrentRoom;
        Invoke("HideRoom", roomMoveDuration);

        Level.CurrentRoom = room;

        //currentRoom.gameObject.SetActive(true);
        Level.CurrentRoom.gameObject.SetActive(true);
        Level.CurrentRoom.transform.DOLocalMoveY(0, roomMoveDuration).SetEase(roomEaseType);

        Vector3 _startPosition = cameraPivot.transform.position;
        Vector3 _endPosition = room.MiddlePoint.transform.position;

        cameraPivot.transform.DOMove(_endPosition, cameraMoveDuration).SetEase(camEaseType);

        //cameraPivot.transform.position = Vector3.MoveTowards(_startPosition, _endPosition, moveDuration);

        RevealRooms();
    }

    public static void RevealRooms()
    {
        Level.CurrentRoom.Explored = true;
        foreach (Room r in Level.CurrentRoom.MyRooms)
        {
            if(!r.Revealed) r.Revealed = true;
            //else if (!r.Explored) r.Explored = true;
            DrawRevealedRooms();
        }
    }

    public static void DrawRevealedRooms()
    {
        foreach (Room r in Level.AllRooms)
        {
            if (!r.Revealed && !r.Explored) r.MyMapIcon.color = new Color(1, 1, 1, 0);
            if (r.Revealed && !r.Explored) r.MyMapIcon.sprite = Level.DefaultRoomIcon;
            if (r.Explored) r.MyMapIcon.sprite = Level.DefaultRoomIcon;
            if (r.Revealed || r.Explored) r.MyMapIcon.color = new Color(1, 1, 1, 1);
            Level.CurrentRoom.MyMapIcon.sprite = Level.CurrentRoomIcon;
            //Level.PreviousRoom.MyMapIcon.sprite = Level.DefaultRoomIcon;
        }
    }

    private void HideRoom()
    {
        Level.PreviousRoom.gameObject.SetActive(false);
    }
}