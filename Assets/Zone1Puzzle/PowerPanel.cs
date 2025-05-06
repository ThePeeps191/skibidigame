using UnityEngine;
using System.Collections.Generic;

public class PowerPanel : MonoBehaviour
{
    public int[] correctOrder = { 1, 3, 2 };
    private List<int> currentInput = new List<int>();
    public GameObject exitDoor;

    public void RegisterSwitchPress(int id)
    {
        currentInput.Add(id);

        for (int i = 0; i < currentInput.Count; i++)
        {
            if (currentInput[i] != correctOrder[i])
            {
                Debug.Log("Wrong order! Reset.");
                currentInput.Clear();
                return;
            }
        }

        if (currentInput.Count == correctOrder.Length)
        {
            Debug.Log("Correct! Door opens.");
            exitDoor.transform.position += new Vector3(0, 3, 0);
        }
    }
}
