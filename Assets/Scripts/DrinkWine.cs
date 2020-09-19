using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DrinkWine : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
        SoundManagerScript.PlaySound("drinking");
    }
}
