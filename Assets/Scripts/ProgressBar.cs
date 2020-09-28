using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float taxiTextNumber = 5f;
    private float introTextNumber = 5f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        GameObject.Find("TaxiText").GetComponent<Canvas>().enabled = false;
        GameObject.Find("IntroText").GetComponent<Canvas>().enabled = true;
        GameObject.Find("EndText").GetComponent<Canvas>().enabled = false;
        
    }
    
    void Update()
    {
        slider.value = slider.value + DrinkWine.winenumber;
        DrinkWine.winenumber = 0;

        if (introTextNumber > 0)
        {
            introTextNumber -= Time.deltaTime;
        }
        
        else if (introTextNumber <= 0)
        {
            GameObject.Find("IntroText").GetComponent<Canvas>().enabled = false;
        }

        if (slider.value >= 100)
        {
            GameObject.Find("Taxi").GetComponent<Taxi>().wineNumber = 1;
            
            if (taxiTextNumber > 0)
            {
                taxiTextNumber -= Time.deltaTime;
                GameObject.Find("TaxiText").GetComponent<Canvas>().enabled = true;
            }
            else if (taxiTextNumber <= 0)
            {
                GameObject.Find("TaxiText").GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
