using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Room attachedRoom;

    private Room ParentRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentRoom = GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

    }
}
