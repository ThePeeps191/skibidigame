using UnityEngine;

public class PowerPanel : MonoBehaviour
{
    public GameObject doorToOpen;
    private bool switch1 = false;
    private bool switch2 = false;
    private bool switch3 = false;

    public void RegisterSwitchPress(int switchID)
    {
        switch (switchID)
        {
            case 1: switch1 = true; break;
            case 2: switch2 = true; break;
            case 3: switch3 = true; break;
        }

        Debug.Log("Switch states: " + switch1 + ", " + switch2 + ", " + switch3);

        if (switch1 && switch2 && switch3)
        {
            Debug.Log("All switches activated. Opening door.");
            doorToOpen.SetActive(false);
        }
    }
}
