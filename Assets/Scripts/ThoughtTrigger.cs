using UnityEngine;

public class ThoughtTrigger : MonoBehaviour
{
    [TextArea]
    public string firstMessage;

    [TextArea]
    public string secondMessage;

    private bool hasInteracted = false;

    public void Interact()
    {
        ThoughtUI thoughtUI = FindAnyObjectByType<ThoughtUI>();

        if (thoughtUI != null)
        {
            if (!hasInteracted)
            {
                thoughtUI.ShowThought(firstMessage);
                hasInteracted = true;
            }
            else
            {
                thoughtUI.ShowThought(secondMessage);
            }
        }
    }
}