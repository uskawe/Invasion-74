using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float yOffset, yOffsetCrouched, moveDelay;
    public float sensitivity, rotationLimit, rotationDelay;

    private float mouseX, mouseY;
    private float rotX, rotY;
    private Transform playerTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotX -= mouseY * sensitivity * Time.deltaTime;
        rotY += mouseX * sensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -rotationLimit, rotationLimit);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(0, rotY, 0), rotationDelay * Time.deltaTime);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            playerTransform.position + playerTransform.up * (FPS.Crouched ? yOffsetCrouched : yOffset),
            moveDelay * Time.deltaTime
        );
    }
}
