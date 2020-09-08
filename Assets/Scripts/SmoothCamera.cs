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
    public float distanceFromTarget = 2;
    
    public Vector2 pitchMinMax = new Vector2(-40,85);

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

        if (distanceFromTarget == 3)
        {
            
        }
    }
}