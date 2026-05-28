using UnityEngine;

public class LockedInteractable : MonoBehaviour
{
    public string requiredItem;

    public Transform pivot;

    public float openAngle = 90f;

    private bool isOpen = false;

    public void Interact()
    {
        Inventory inventory = Object.FindAnyObjectByType<Inventory>();

        if (inventory == null)
            return;

        if (!inventory.HasItem(requiredItem))
        {
            Debug.Log("Locked");
            return;
        }

        if (!isOpen)
        {
            pivot.Rotate(0, openAngle, 0);

            isOpen = true;

            Debug.Log("Opened");
        }
        else
        {
            pivot.Rotate(0, -openAngle, 0);

            isOpen = false;
        }
    }
}