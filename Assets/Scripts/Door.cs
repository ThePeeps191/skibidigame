using UnityEngine;

public class Door : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float openSpeed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;
    private bool isAnimating = false;
    public bool isTouching = false;
    public float maxDistance = 2;
    public Collider playerCollider;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles - new Vector3(0, rotationAngle, 0)); // ← Opposite direction
    }

    void Update()
    {
        DetectCollider(playerCollider);
        if (Input.GetKeyDown(KeyCode.E) && !isAnimating && isTouching)
        {
            isOpen = !isOpen;
            isAnimating = true;
        }

        if (isAnimating)
        {
            Quaternion targetRotation = isOpen ? openRotation : closedRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isAnimating = false;
            }
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