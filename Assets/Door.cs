using UnityEngine;

public class Door : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float openSpeed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;
    private bool isAnimating = false;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles - new Vector3(0, rotationAngle, 0)); // ← Opposite direction
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAnimating)
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
}