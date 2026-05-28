using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class NoteInteraction : MonoBehaviour
{
    public GameObject noteUI;
    public TextMeshProUGUI noteText;

    [TextArea]
    public string message;

    private bool isReading = false;

    void Update()
    {
        if (isReading && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            CloseNote();
        }
    }

    public void Interact()
    {
        noteUI.SetActive(true);

        noteText.text = message;

        isReading = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseNote()
    {
        noteUI.SetActive(false);

        isReading = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}