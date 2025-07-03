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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GoToRoom(Room room, Arrow arrow)
    {
        currentRoom.gameObject.SetActive(false);
        currentRoom = room;
        currentRoom.gameObject.SetActive(true);

        isMoving = true;

        Vector3 _startPosition = cameraPivot.transform.position;
        Vector3 _endPosition = room.MiddlePoint.transform.position;

        float _elapsed = 0f;

        while (_elapsed < moveDuration)
        {
            //cameraPivot.transform.position = Vector3.Lerp(_startPosition, _endPosition, _elapsed / moveDuration);

            //_elapsed += Time.deltaTime;

            _elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(_elapsed / moveDuration);
            cameraPivot.transform.position = Vector3.Lerp(_startPosition, _endPosition, t);
            yield return null;
        }

        cameraPivot.transform.position = _endPosition;
        isMoving = false;
        arrow.Clicked = false;
    }
}
