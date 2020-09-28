using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{

    public float countNumber;
    [SerializeField] private TextMeshPro endText;
    
    void Start()
    {
        countNumber = GameObject.Find("Countdown").GetComponent<CountdownTimer>().currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        endText.text = "Your're a real alcoholic! You've drank all the bottles in " + 
                       countNumber.ToString("0") + " seconds!";
    }
}
