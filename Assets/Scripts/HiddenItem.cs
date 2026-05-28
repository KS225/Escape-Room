using UnityEngine;

public class HiddenItem : MonoBehaviour
{
    public GameObject hiddenObject;

    public Transform spawnPoint;

    private bool alreadyOpened = false;

    public void Interact()
    {
        if (alreadyOpened)
            return;

        hiddenObject.SetActive(true);

        hiddenObject.transform.position = spawnPoint.position;

        Debug.Log("Something fell out.");

        alreadyOpened = true;
    }
}