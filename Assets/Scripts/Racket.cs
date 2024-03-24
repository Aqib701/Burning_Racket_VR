using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class Racket : MonoBehaviour
{
    [SerializeField]
    Mananger manager;

    [SerializeField]
    GameObject Ball;
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    Component[] destroy;

    void OnCollisionEnter(Collision collision)
    {
      
    }
    public void RacketGrabbed()
    {
        this.gameObject.layer = 11;

        // StartCoroutine(StartMatch());
     //   for (int i = 0; i < destroy.Length; i++)
      //  {
     //       Destroy(destroy[i]);
      //  }
      //  Ball.SetActive(true);
        Canvas.SetActive(false);
    }

    IEnumerator StartMatch()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < destroy.Length; i++)
        {
            Destroy(destroy[i]);
        }
     //   Destroy(GetComponent<BNG.GrabbableHaptics>());
      //  Destroy(GetComponent<BNG.GrabbableUnityEvents>());
      //  Destroy(GetComponent<BNG.CollisionSound>());
     //    Destroy(GetComponent<BNG.Grabbable>());
        Ball.SetActive(true);
        Canvas.SetActive(false);
    }
}
