using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Directions")]
    //[SerializeField] private Room NorthRoom;
    //[SerializeField] private Room SouthRoom;
    //[SerializeField] private Room WestRoom;
    //[SerializeField] private Room EastRoom;
    [SerializeField] private Room[] AllRooms = new Room[4];

    [Space(10)]

    [Header("Setup")]
    [SerializeField] private GameObject MiddlePoint;
    [SerializeField] private GameObject ArrowPrefab;

    private void Awake()
    {
        
    }
    void Start()
    {
        //Room[] AllRooms = new Room[] {NorthRoom, SouthRoom, WestRoom, EastRoom};

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
