using UnityEngine;

public class PowerLever : MonoBehaviour
{
    public int switchID;
    public PowerPanel panel;

    private void OnMouseDown()
    {
        panel.RegisterSwitchPress(switchID);
    }
}
