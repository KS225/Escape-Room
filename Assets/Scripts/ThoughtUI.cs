using UnityEngine;
using TMPro;
using System.Collections;

public class ThoughtUI : MonoBehaviour
{
    public TextMeshProUGUI thoughtText;

    public float displayTime = 5f;

    private Coroutine currentRoutine;

    void Start()
    {
        ShowThought("What the hell is this place...?");
    }

    public void ShowThought(string message)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(DisplayThought(message));
    }

    IEnumerator DisplayThought(string message)
    {
        thoughtText.text = message;
        thoughtText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        thoughtText.gameObject.SetActive(false);
    }
}