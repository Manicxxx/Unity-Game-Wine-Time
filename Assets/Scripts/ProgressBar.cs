using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;
    private float targetValue = 0;
    public float fillSpeed = 0.5f;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Progress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetValue)
            slider.value += fillSpeed *Time.deltaTime;
        
    }

    public void Progress(float newProgress)
    {
        targetValue = slider.value + newProgress;
    }

}
