using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private List<Room> allRooms = new List<Room>(4);

    [Header("Interactables")]
    [SerializeField] public List<Transform> LocalInteractables;

    [Space(10)]
    [Header("Setup")]
    [SerializeField] public GameObject MiddlePoint;

    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private bool startingRoom;

    private void Awake()
    {
        SpawnArrows();
    }

    private void Start()
    {
        MiddlePoint.transform.SetParent(null, true);
        this.transform.DOLocalMoveY(-20, 0);
        if (!startingRoom)
        {
            this.gameObject.SetActive(false);
            foreach (Transform i in LocalInteractables)
            {
                i.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDisable()
    {
        //this.gameObject.transform.DOLocalMoveY()
        foreach (Transform t in LocalInteractables)
        {
            if(t != null)
                t.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        //this.gameObject.transform.DOMoveY(0, 1, true);
        foreach (Transform t in LocalInteractables)
        {
            if (t != null)
                t.gameObject.SetActive(true);
        }
    }

    private void SpawnArrows()
    {
        foreach (Room room in allRooms)
        {
            if (room != null)
            {
                Vector3 directionToTarget = (room.transform.position - transform.position).normalized;

                Vector3 spawnPosition = transform.position + (directionToTarget * 4f);
                spawnPosition.y = 1;

                GameObject prefab = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
                prefab.transform.LookAt(room.transform);

                prefab.GetComponent<Arrow>().AttachedRoom = room;
                prefab.transform.SetParent(transform);
            }
        }

        this.GetComponent<BoxCollider>().enabled = false;
    }

    private void TimedDisable()
    {
        this.gameObject.SetActive(false);
    }
}