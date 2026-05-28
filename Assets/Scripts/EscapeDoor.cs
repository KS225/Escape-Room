using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public GameObject topHinge;

    public GameObject bottomHinge;

    private bool opened = false;

    public void Interact()
    {
        if (opened)
            return;

        if (!topHinge.activeSelf &&
            !bottomHinge.activeSelf)
        {
            Debug.Log("Door forced open");

            transform.Rotate(0, 90, 0);

            GetComponent<Collider>().enabled = false;

            opened = true;
        }
        else
        {
            Debug.Log("The hinges are still attached.");
        }
    }
}