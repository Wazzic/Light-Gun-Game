using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public float horizontalSpeed = 1f;  // Horizontal rotation speed
    public float verticalSpeed = 1f;    // Vertical rotation speed
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; //Sets the main camera as the one which displays
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed; // Gets X-axis input from mouse
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;   // Gets Y-axis input from mouse

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90); // Stops the player from spinning the camera around vertically

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f); // locks the camera

        Cursor.lockState = CursorLockMode.Locked; //This Works not practible for testing
        Cursor.visible = false;
    }
}