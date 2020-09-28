using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    public Image whiteFade;
    public float fadeNumber = 0;

    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);
    }

    void Update()
    {
        FadeOut();
    }

    void FadeOut()
    {
        if (fadeNumber == 1)
        {
            whiteFade.CrossFadeAlpha(1,2, false);
            GameObject.Find("Progress").GetComponent<Canvas>().enabled = false;
            GameObject.Find("EndText").GetComponent<Canvas>().enabled = true;
        }
    }
}
