using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 1000;
    bool hasPlayer = false;
    bool beingCarried = false;
    private bool touched = false;
    
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        
        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        
        if (hasPlayer && !beingCarried && Input.GetButtonDown("Pickup"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().enabled = false;
            SoundManagerScript.PlaySound("pickup");
            transform.parent = playerCam;
            beingCarried = true;
        }
        
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
        
            if (Input.GetKeyDown(KeyCode.R))
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                SoundManagerScript.PlaySound("drop");
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
