using UnityEngine;
using System.Collections;

public class PointLightFlicker : MonoBehaviour
{
    public Light[] lightsToFlicker;      // Assign your point lights in the Inspector
    public float minFlickerDelay = 0.1f; // Minimum time between flickers
    public float maxFlickerDelay = 1f;   // Maximum time between flickers

    void Start()
    {
        // Start a flicker routine for each light
        foreach (Light light in lightsToFlicker)
        {
            StartCoroutine(FlickerLightRoutine(light));
        }
    }

    IEnumerator FlickerLightRoutine(Light light)
    {
        while (true)
        {
            float waitTime = Random.Range(minFlickerDelay, maxFlickerDelay);
            yield return new WaitForSeconds(waitTime);

            light.enabled = !light.enabled;
        }
    }
}