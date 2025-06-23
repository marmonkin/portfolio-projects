using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [Space(10)]

    [Header("Setup")]
    [SerializeField] public GameObject MiddlePoint;
    [SerializeField] private GameObject ArrowPrefab;

    [HideInInspector] public List <Room> AllRooms = new List<Room>(4);

    private void Awake()
    {
        
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
        Debug.Log(AllRooms[0]);

        foreach (Room room in AllRooms)
        {
            if (room != null)
            {

                Vector3 directionToTarget = (room.transform.position - transform.position).normalized;

                Vector3 spawnPosition = transform.position + (directionToTarget * 4f);

                spawnPosition.y = 1;

                GameObject prefab = Instantiate(ArrowPrefab, spawnPosition, Quaternion.identity);
                prefab.transform.LookAt(room.transform);

                prefab.GetComponent<Arrow>().attachedRoom = room;
                prefab.transform.SetParent(transform);
            }
        }

        this.GetComponent<BoxCollider>().enabled = false;
    }
}
