using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *
 * Handles Behaviour of the Gameplay Ball
 * 
 */


public class Ball : MonoBehaviour
{
    bool once = false;

    [SerializeField]
    GameObject Playerhit;
     void OnCollisionEnter(Collision collision)
    {
        if (once)
            return;

        transform.GetChild(0).GetComponent<AudioSource>().Stop();

        if(collision.gameObject.tag== "Racket")
        {
            Mananger.instance.IncreaseScore();
        }

        if (collision.gameObject.tag == "PlayerCollider")
        {
            Mananger.instance.PlayerHit();
            collision.gameObject.GetComponent<AudioSource>().Play();
           GameObject go= GameObject.Instantiate(Playerhit, collision.transform.position, Quaternion.identity);
            Destroy(go, 2);
            Debug.Log(collision.gameObject.name);
        }

        Invoke("Destroynow", 1);
    }

    void Destroynow()
    {
        Destroy(this.gameObject);
    }
}
