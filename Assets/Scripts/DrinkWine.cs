using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DrinkWine : MonoBehaviour
{
    public static float winenumber;
    void OnMouseDown()
    {
        Destroy(gameObject);
        SoundManagerScript.PlaySound("glug");
        SoundManagerScript.PlaySound("drinking");
        winenumber = 10f;
    }
}
