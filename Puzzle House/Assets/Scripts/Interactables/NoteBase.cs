using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteBase : MonoBehaviour, IInteractable
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    [Header("UI")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text canvasText;
    [SerializeField] private Image canvasImage;


    [Space(10)]
    [Header("Note Parameters")]
    [SerializeField] [TextArea] private string noteText;
    [SerializeField] private Image noteImage;

    private bool isOpen = false;
    private void OnEnable()
    {
        if (canvas == null)
        {
            canvas = FindAnyObjectByType<Canvas>().gameObject;
        }

        if (canvasImage == null)
        {
            canvasImage = canvas.GetComponentInChildren<Image>();
        }

        if(canvasText == null)
        {
            canvasText = canvasImage.GetComponentInChildren<TMP_Text>();
        }

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
    }

    private void CloseNote()
    {
        canvas.SetActive(false);
        canvasText.text = null;
        canvasImage = null;
        isOpen = false;
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
