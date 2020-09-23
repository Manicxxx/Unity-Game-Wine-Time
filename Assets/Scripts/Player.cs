using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float walkSpeed = 0.7f;
    public float runSpeed = 2f;
    public float gravity = -12f;
    public float jumpHeight = 2f;
    public float airControlPercent = 1f;

    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    private float speedSmoothVelocity;
    private float currentSpeed;
    private float velocityY;

    private Animator animator;
    private Transform cameraT;
    private Camera fpsCam;

    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        
        fpsCam = Camera.main;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);
        
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0f));

        Move(inputDir, running);
        
        // when space is pressed, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move(Vector2 inputDir, bool running)
    {
        // Stop the Direction of the Player to snap back to default if you dont press a key
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            // smoothes transitions between animations
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }
        
        // if we're running -> speed = runspeed, otherwise speed = walkspeed
        // times magnitude because without a pressed key the speed will be 0
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;
        
        // translates speed to player and adds gravity
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        // when player is on the ground, it won't be pulled downwards
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        // adjustes animation speed to actual speed
        // when collision appears, animation will stop or slow down
        float animationSpeedPercent = (running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * 0.5f;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            // equation for gravity when falling from a jump
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }

    // change SmoothTime when in the air
    float GetModifiedSmoothTime(float smoothTime)
    {
        return smoothTime;
    }
}
