using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Racket")
        {
            Mananger.instance.CoolRacket();
            GetComponent<AudioSource>().Play();
        }
    }
}
