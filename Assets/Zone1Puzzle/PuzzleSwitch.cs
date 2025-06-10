using UnityEngine;

public class PuzzleSwitch : MonoBehaviour
{
    public int switchID;
    public PowerPanel panel;
    public Renderer indicatorRenderer;

    private bool isPlayerNear = false;
    private bool isActivated = false;

    public bool isTouching = false;
    public float maxDistance = 2;
    public Collider playerCollider;

    void Update()
    {
        if (isPlayerNear && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E on Switch " + switchID);
            isActivated = true;
            panel.RegisterSwitchPress(switchID);

            if (indicatorRenderer != null)
                indicatorRenderer.material.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered switch trigger area.");
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something exited: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited switch trigger area.");
            isPlayerNear = false;
        }
    }
}
