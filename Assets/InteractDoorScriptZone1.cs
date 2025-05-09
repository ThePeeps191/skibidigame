using UnityEngine;

public class InteractDoorScriptZone1 : MonoBehaviour
{
    public int id; // id 1: canuse text, id 2: nouse text
    public GameObject this_text;
    public GameObject other_text;

    public bool isTouching = false;
    public float maxDistance = 2;
    public Collider playerCollider;
    public Collider doorCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (id == 1)
        {
            this_text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollider(playerCollider, doorCollider);
        if (isTouching)
        {
            if (id == 2)
            {
                other_text.SetActive(true);
                this_text.SetActive(false);
            }
        } else
        {
            if (id == 1)
            {
                other_text.SetActive(true);
                this_text.SetActive(false);
            }
        }
    }

    void DetectCollider(Collider playr, Collider other)
    {
        // other object is close
        if (Vector3.Distance(playr.transform.position, other.transform.position) < maxDistance)
        {
            isTouching = true; // they are touching AND close
        }
        else
        {
            isTouching = false;
        }
    }
}
