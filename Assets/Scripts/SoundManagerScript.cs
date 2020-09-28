using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip drinking, pickup, drop, littlebitdrunk, glug, taxiHorn;
    private static AudioSource audioSrc;
    
    void Start()
    {
        drinking = Resources.Load<AudioClip>("DrinkingSound");
        pickup = Resources.Load<AudioClip>("Pickup");
        drop = Resources.Load<AudioClip>("Drop");
        littlebitdrunk = Resources.Load<AudioClip>("LittleBitDrunk");
        glug = Resources.Load<AudioClip>("Glug");
        taxiHorn = Resources.Load<AudioClip>("TaxiHorn");
        
        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "drinking":
                audioSrc.PlayOneShot(drinking);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickup);
                break;
            case "drop":
                audioSrc.PlayOneShot(drop);
                break;
            case "littlebitdrunk":
                audioSrc.PlayOneShot(littlebitdrunk);
                break;
            case "glug":
                audioSrc.PlayOneShot(glug);
                break; 
            case "taxiHorn":
                audioSrc.PlayOneShot(taxiHorn);
                break;
        }
    }
}
