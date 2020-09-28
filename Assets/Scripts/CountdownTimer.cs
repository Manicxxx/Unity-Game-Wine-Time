using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
  public float currentTime = 0f;
  private float startingTime = 0f;
  [SerializeField] private Text countdownText;

  private void Start()
  {
    currentTime = startingTime;
  }

  private void Update()
  {
    if (GameObject.Find("Progress").GetComponent<Canvas>().enabled == true)
    {
      currentTime += 1 * Time.deltaTime;
      countdownText.text = currentTime.ToString("0.0") + " s";
    }
    else if (GameObject.Find("Progress").GetComponent<Canvas>().enabled == false)
    {
      currentTime = currentTime;
    }
  }
}
