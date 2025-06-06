using UnityEngine;

public class DoorExitScript : MonoBehaviour
{
    public bool isTouching = false;
    public float maxDistance = 2;
    public Collider playerCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollider(playerCollider);
        if (Input.GetKeyDown(KeyCode.E) && isTouching)
        {
            SceneChanger.Instance.ChangeScene("Zone 2");
        }
    }

    void DetectCollider(Collider other)
    {
        // other object is close
        if (Vector3.Distance(other.transform.position, this.transform.position) < maxDistance)
        {
            isTouching = true; // they are touching AND close
        }
        else
        {
            isTouching = false;
        }
    }
}
