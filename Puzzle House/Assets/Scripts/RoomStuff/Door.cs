using UnityEngine;

public class Door : MonoBehaviour
{
    private Room myRoom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRoom = GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
