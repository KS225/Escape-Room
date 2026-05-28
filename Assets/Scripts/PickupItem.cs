using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "Key";

    public void Interact()
    {
        Inventory inventory = Object.FindAnyObjectByType<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemName);
        }

        Destroy(gameObject);
    }
}