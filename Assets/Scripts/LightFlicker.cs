using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;

    public float minIntensity = 0.9f;
    public float maxIntensity = 1.15f;

    public float flickerInterval = 0.08f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= flickerInterval)
        {
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
            timer = 0f;
        }
    }
}