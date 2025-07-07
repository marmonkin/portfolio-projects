using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private NewControls controls;

    [SerializeField]
    private Transform newSelection;
    private Transform currentSelection;

    public float DistanceThreshold;

    [Header("Cursor Textures")]
    [SerializeField]
    private Texture2D selectionTexture;
    [SerializeField]
    private Texture2D defaultTexture;

    private InteractablesManager iManager;
    private Cursor interactiveCursor;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;

    private bool isInteractive = false;

    private void Awake()
    {
        DefaultCursor();

        iManager = this.GetComponent<InteractablesManager>();

        controls = new NewControls();
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursor;
        MakeCursorInteractive += InteractiveCursor;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        FindInteractable();
    }

    private void FindInteractable()
    {
        newSelection = null;

        for(int itemIndex = 0;
            itemIndex < iManager.Interactables.Count;
            itemIndex++)
        {
            Vector3 mouseOffset =
                iManager.Interactables[itemIndex].position 
                - new Vector3(
                    controls.Mouse.Position.ReadValue<Vector2>().x,
                    controls.Mouse.Position.ReadValue<Vector2>().y,
                    0f);
            float sqrMag = mouseOffset.sqrMagnitude;

            if (sqrMag < DistanceThreshold * DistanceThreshold)
            {
                newSelection = iManager.Interactables[itemIndex].transform;

                if(isInteractive == false)
                {
                    InteractiveCursor();
                }
                break;
            }
        }

        if(currentSelection != newSelection)
        {
            currentSelection = newSelection;
            DefaultCursor();
        }
    }

    private void InteractiveCursor()
    {
        isInteractive = true;
        Vector2 hotspot = new Vector2(selectionTexture.width / 2, 0);

        Cursor.SetCursor(selectionTexture, hotspot, CursorMode.Auto);
    }

    private void DefaultCursor()
    {
        isInteractive = false;
        Vector2 hotspot = new Vector2(defaultTexture.width / 2, 0);

        Cursor.SetCursor(defaultTexture, hotspot, CursorMode.Auto);
    }

    

    private void StartedClick()
    {

    }

    private void EndedClick()
    {
        OnClickInteractable();
    }

    private void OnClickInteractable()
    {
        if (newSelection != null)
        {
            IInteractable interactable =
                newSelection.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnClickAction();
            }
            newSelection = null;
        }
    }
}
