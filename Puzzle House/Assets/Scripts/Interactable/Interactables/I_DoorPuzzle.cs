using System.Collections.Generic;
using UnityEngine;

public class I_DoorPuzzle : MonoBehaviour, IInteractable
{
    public bool DoNotRespawn { get; set; }
    public bool NoRespawn;

    private GameManager gManager;

    public List<I_DoorCollectable> Collectables;

    private void OnEnable()
    {
        gManager = FindAnyObjectByType<GameManager>();
        DoNotRespawn = NoRespawn;
    }

    public void OnClickAction()
    {
        int collected = 0;
        foreach (I_DoorCollectable item in Collectables)
        {
            if (item.Collected)
            {
                collected++;
            }
        }
        if (Collectables.Count == collected)
        {

        }
    }
}
