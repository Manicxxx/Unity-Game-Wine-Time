using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    public Transform player;
    private float number = 1f;
    public float wineNumber = 0;
    public void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        
        if (dist <= 20.0f && number == 1 && wineNumber == 1)
        {
            SoundManagerScript.PlaySound("taxiHorn");
            number = 0;
            GameObject.Find("FinishText").GetComponent<Fadeout>().fadeNumber = 1;
            SoundManagerScript.PlaySound("redRedWine");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
