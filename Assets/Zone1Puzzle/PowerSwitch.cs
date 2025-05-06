using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    public int switchID;
    public PowerPanel panel;

    private void OnMouseDown()
    {
        panel.RegisterSwitchPress(switchID);
    }
}
