﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }
    
    //Rotates Object in a certain angle
    void RotateObject()
    {
        transform.Rotate(Vector3.up, angle * Time.deltaTime);
    }
}
