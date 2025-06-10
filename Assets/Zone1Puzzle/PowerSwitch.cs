using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    public int switchID;
    public PowerPanel panel;
    public GameObject indicatorLight;

    private bool isPlayerNear = false;
    private bool isActivated = false;

    void Update()
    {
        if (isPlayerNear && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = true;
            panel.RegisterSwitchPress(switchID);
            ActivateVisuals();
        }
    }

    private void ActivateVisuals()
    {
        if (indicatorLight != null)
        {
            Renderer r = indicatorLight.GetComponent<Renderer>();
            if (r != null)
                r.material.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}
