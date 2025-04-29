using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public Material ceilingMaterial;           // Assign your ceiling material in the Inspector
    public Color emissionColor = Color.white;  // Emission color when "on"
    public float minFlickerDelay = 0.1f;       // Minimum time between flickers
    public float maxFlickerDelay = 1f;         // Maximum time between flickers

    private void Start()
    {
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minFlickerDelay, maxFlickerDelay);
            yield return new WaitForSeconds(waitTime);

            // Toggle emission
            bool isCurrentlyEmitting = ceilingMaterial.IsKeywordEnabled("_EMISSION");

            if (isCurrentlyEmitting)
            {
                ceilingMaterial.DisableKeyword("_EMISSION");
                ceilingMaterial.SetColor("_EmissionColor", Color.black);
            }
            else
            {
                ceilingMaterial.EnableKeyword("_EMISSION");
                ceilingMaterial.SetColor("_EmissionColor", emissionColor);
            }
        }
    }
}