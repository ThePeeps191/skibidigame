using UnityEngine;

public class TitleTextPulse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale =  Mathf.Max(1, 1 + Mathf.Cos(Time.time * (145 / 60) * Mathf.PI * 2) / 7);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
