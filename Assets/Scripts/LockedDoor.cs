using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public Transform pivot;

    public string requiredItem = "Key";

    private bool isOpen = false;
    private bool isUnlocked = false;

    public void Interact()
    {
        Inventory inventory = Object.FindAnyObjectByType<Inventory>();

        if (!isUnlocked)
        {
            if (inventory != null && inventory.HasItem(requiredItem))
            {
                isUnlocked = true;

                Debug.Log("Door unlocked with " + requiredItem);
            }
            else
            {
                Debug.Log("Door is locked");
                return;
            }
        }

        if (!isOpen)
        {
            pivot.Rotate(0, 90, 0);
            isOpen = true;
        }
        else
        {
            pivot.Rotate(0, -90, 0);
            isOpen = false;
        }
    }
}