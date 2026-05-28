using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}