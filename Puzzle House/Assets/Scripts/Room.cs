using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private List <Room> allRooms = new List<Room>(4);


    [Space(10)]

    [Header("Setup")]
    [SerializeField] public GameObject MiddlePoint;
    [SerializeField] private GameObject arrowPrefab;


    private void Awake()
    {
        SpawnArrows();
    }
    void Start()
    {
        MiddlePoint.transform.SetParent(null, true);
        this.transform.DOLocalMoveY(-20, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        //this.gameObject.transform.DOLocalMoveY()
    }

    private void OnEnable()
    {
        //this.gameObject.transform.DOMoveY(0, 1, true);
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
