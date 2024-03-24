using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScore : MonoBehaviour
{
    [SerializeField]
    Mananger manager;

     void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag=="ball")
        {
            manager.IncreaseScore();
        }
    }
}
