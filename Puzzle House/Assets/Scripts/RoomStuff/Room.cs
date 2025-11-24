using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [Header("Rooms")]
    public List<Room> MyRooms = new List<Room>(4);

    [Header("Interactables")]
    [SerializeField] public List<Transform> LocalInteractables;

    [Space(10)]
    [Header("Setup")]
    [SerializeField] public GameObject MiddlePoint;

    [SerializeField] private GameObject arrowPrefab;
    public Image MyMapIcon;
    [SerializeField] private bool startingRoom;

    [HideInInspector]
    public bool Revealed;
    [HideInInspector]
    public bool Explored;

    private void Awake()
    {
        SpawnArrows();
    }

    private void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;

        Level.AllRooms.Add(this);

        MiddlePoint.transform.SetParent(null, true);
        this.transform.DOLocalMoveY(-20, 0);
        if (!startingRoom)
        {
            this.gameObject.SetActive(false);
            foreach (Transform i in LocalInteractables)
            {
                if (!i.GetComponentInChildren<IInteractable>().DoNotRespawn)
                {
                    i.gameObject.SetActive(false);
                }
            }
        }
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
            if (t != null && t.GetComponentInChildren<IInteractable>() != null)
            {
                if (!t.GetComponentInChildren<IInteractable>().DoNotRespawn)
                {
                    t.gameObject.SetActive(true);
                }
            }
            else t.gameObject.SetActive(true);
        }
    }

    private void SpawnArrows()
    {
        foreach (Room room in MyRooms)
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

        
    }
}