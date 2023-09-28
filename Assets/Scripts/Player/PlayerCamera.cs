using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject targetCam;
    float mouseX;
    float mouseY;

    private void Awake()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
    }

    private void FixedUpdate()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX;

        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);

        Vector3 currentCameraRotation = targetCam.transform.localEulerAngles;
        currentCameraRotation.x -= mouseY;
        targetCam.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x, Vector3.right);
    }
}
