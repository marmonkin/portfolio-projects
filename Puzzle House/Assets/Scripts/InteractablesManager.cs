using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> interactables;

    public List<Transform> Interactables
    {
        get => interactables;
    }

    private Camera mainCamera;

    public static Action<Transform> AddInterEvent;
    public static Action<Transform> RemoveInterEvent;

    private void Awake()
    {
        AddInterEvent += AddInterList;
        RemoveInterEvent += RemoveInterList;
    }

    void Start()
    {
        mainCamera = Camera.main;

        //ChildrenToScreenPoint();
    }

    void Update()
    {
        
    }

    //private void ChildrenToScreenPoint()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);

    //        transform.GetChild(i).localScale = Vector3.one;
    //    }
    //}

    private void AddInterList(Transform transform)
    {
        interactables.Add(transform);
    }

    private void RemoveInterList(Transform transform)
    {
        interactables.Remove(transform);
    }
}
