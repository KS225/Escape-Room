using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PasswordLockedObject : MonoBehaviour
{
    public GameObject passwordPanel;

    public TMP_InputField passwordInput;

    public string correctPassword = "425";

    public GameObject rewardPrefab;

    public Transform spawnPoint;

    private bool unlocked = false;

    public void Interact()
    {
        if (unlocked)
            return;

        passwordPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CheckPassword()
    {
        if (passwordInput.text == correctPassword)
        {
            unlocked = true;

            Debug.Log("Unlocked!");

            Instantiate(rewardPrefab,
                        spawnPoint.position,
                        spawnPoint.rotation);

            passwordPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("Wrong Password");
        }
    }

    void Update()
    {
        if (passwordPanel.activeSelf &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            passwordPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}