using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseNotes : MonoBehaviour
{
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rotates Object in a certain angle
    void RotateObject()
    {
        transform.Rotate(Vector3.up, angle * Time.deltaTime);
    }

    //Object always looks at target
    public Transform target;
    void LookAt()
    {
        transform.LookAt(target);
    }

    //Changes kinematic to off/on if space is pressed
    void Kinematic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.gameObject.GetComponent<Rigidbody>().isKinematic =
                !transform.gameObject.GetComponent<Rigidbody>().isKinematic;
        }
    }

    public float offset;
    private Rigidbody rb;
    
    //It would accelerate the Gameobject
    void FixUpdate()
    {
        //This one into the Start() fct
        rb = this.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(transform.forward * offset, ForceMode.Acceleration);
        }
    }

    // explaining the Transform object in the unity environment
    [Header("Parameter values")]
    [Tooltip("Enemy that is going to be killed")]
    public Transform enemy;
    
    // in the top right corner on the unity inspector you can switch between normal and debug
    // -> also see private variables
    
    //Trick: Strg + Shift + f, select main camera and game view will change
}
