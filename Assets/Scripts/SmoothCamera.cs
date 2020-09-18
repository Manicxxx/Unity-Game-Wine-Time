using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private float yaw;
    private float pitch;
    
    public float mouseSensitivity = 5f;
    public float rotationSmoothTime = 0.12f;
    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    public Transform target;
    public float distanceFromTarget = 0f;
    
    public Vector2 pitchMinMax = new Vector2(-25,85);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Mouse Input
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Limitation for mouse movement
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity,
            rotationSmoothTime);
     
        transform.eulerAngles = currentRotation;
        
        transform.position = target.position - transform.forward * distanceFromTarget;
        
        // Switch between FPS and TPS
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f) {
            if (distanceFromTarget > 0) {
                distanceFromTarget = distanceFromTarget - 1f;
            }
        }
        else if (d < 0f) {
            if (distanceFromTarget < 3f) {
                distanceFromTarget = distanceFromTarget + 1f;
            }
        }

        if (Input.GetButtonDown("Camera")) {
            if (distanceFromTarget > 0) {
                distanceFromTarget = distanceFromTarget - 1;
            }
            else if (distanceFromTarget == 0)
            {
                distanceFromTarget = 3;
            }
        }
    }
}