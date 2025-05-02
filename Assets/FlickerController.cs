using UnityEngine;
using System.Collections;

public class SyncedFlicker : MonoBehaviour
{
    [Header("Lights")]
    public Light[] lightsToFlicker;

    [Header("Material Emission")]
    public Material ceilingMaterial;              // Assign the material that uses the emission map
    public Color emissionOnColor = Color.white;   // Emission color when on

    [Header("Flicker Timing")]
    public float minFlickerDelay = 0.1f;
    public float maxFlickerDelay = 1f;

    private bool isOn = true;

    void Start()
    {
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minFlickerDelay, maxFlickerDelay);
            yield return new WaitForSeconds(waitTime);

            isOn = !isOn;

            // Toggle lights
            foreach (Light light in lightsToFlicker)
            {
                if (light != null)
                    light.enabled = isOn;
            }

            // Toggle emission
            if (ceilingMaterial != null)
            {
                if (isOn)
                {
                    ceilingMaterial.EnableKeyword("_EMISSION");
                    ceilingMaterial.SetColor("_EmissionColor", emissionOnColor);
                }
                else
                {
                    ceilingMaterial.DisableKeyword("_EMISSION");
                    ceilingMaterial.SetColor("_EmissionColor", Color.black);
                }
            }
        }
    }
}