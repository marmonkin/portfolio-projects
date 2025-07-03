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
        this.gameObject.SetActive(false);
    }
    void Start()
    {
        SpawnArrows();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnArrows()
    {
        Debug.Log(allRooms[0]);

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
}
