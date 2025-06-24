using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomCast : MonoBehaviour
{

    [SerializeField] private string TargetTag;
    [SerializeField] private float MaxDistance;

    [Space(10)]
    [Header("Overrides")]
    public bool blocked;
    [SerializeField][ShowIf("blocked")] 

    private Room room;
    private List<GameObject> DetectedObjects = new List<GameObject>();

    private void Awake()
    {
        room = this.GetComponent<Room>();

        FindNearRooms();
    }

    private void FindNearRooms()
    {
        Vector3[] directions = new Vector3[]
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        foreach (Vector3 direction in directions)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, MaxDistance, ~0))
            {
                Debug.DrawRay(transform.position, direction * MaxDistance, Color.red, 0.1f);

                if (hit.collider.CompareTag(TargetTag))
                {
                    float distance = Vector3.Distance(transform.position, hit.transform.position);
                    if (distance <= MaxDistance && !DetectedObjects.Contains(hit.collider.gameObject))
                    {
                        DetectedObjects.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        foreach (GameObject obj in DetectedObjects)
        {
            //room.AllRooms.Add(obj.GetComponent<Room>());
        }
    }
}
