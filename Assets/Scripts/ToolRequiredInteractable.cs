using UnityEngine;

public class ToolRequiredInteractable : MonoBehaviour
{
    public string requiredTool = "Screwdriver";

    public GameObject objectToDisable;

    private bool used = false;

    public void Interact()
    {
        if (used)
            return;

        Inventory inventory = Object.FindAnyObjectByType<Inventory>();

        if (inventory == null)
            return;

        if (!inventory.HasItem(requiredTool))
        {
            Debug.Log("Need " + requiredTool);

            return;
        }

        Debug.Log(requiredTool + " used");

        objectToDisable.SetActive(false);

        used = true;
    }
}