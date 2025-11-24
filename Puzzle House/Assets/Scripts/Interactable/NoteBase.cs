using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteBase : MonoBehaviour, IInteractable
{
    public bool DoNotRespawn { get; set; }

    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    [Header("Note Parameters")]
    [SerializeField] [TextArea] private string noteText;
    [SerializeField] private Image noteImage;

    private GameObject canvas;
    private TMP_Text canvasText;
    private Image canvasImage;

    private GameManager gManager;

    private bool isOpen = false;
    private void OnEnable()
    {
        gManager = FindAnyObjectByType<GameManager>();

        canvas = gManager.NoteOverlay.gameObject;
        canvasImage = gManager.NoteBgImage;
        canvasText = gManager.NoteText;
    }

    public void OnClickAction()
    {
        if (!isOpen)
            ShowNote();
    }

    private void ShowNote()
    {
        canvasText.text = noteText;
        canvasImage = noteImage;

        canvas.SetActive(true);
        isOpen = true;

        gManager.CanInteract = false;
    }

    private void CloseNote()
    {
        canvas.SetActive(false);
        canvasText.text = null;
        canvasImage = null;
        isOpen = false;

        gManager.CanInteract = true;
    }

    private void Update()
    {
        if (isOpen)
        {
            if(Input.GetKeyUp(closeKey))
            {
                CloseNote();
            }
        }
    }
}
