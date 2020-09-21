using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    
    void Update()
    {
        slider.value = slider.value + DrinkWine.winenumber;
        DrinkWine.winenumber = 0;
    }
}
