using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Room AttachedRoom;
    
    [HideInInspector]public bool Clicked;

    private Room parentRoom;
    private GameManager gManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentRoom = GetComponentInParent<Room>();
        gManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicked)
        {
            StartCoroutine(gManager.GoToRoom(AttachedRoom, this));
            Clicked = false;
        }
    }

    private void OnMouseDown()
    {
        //StartCoroutine(gManager.GoToRoom(AttachedRoom));
        Clicked = true;
    }
}
