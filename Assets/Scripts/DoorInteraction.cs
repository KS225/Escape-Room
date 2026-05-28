using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform pivot;

    private bool isOpen = false;

    public void Interact()
    {
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