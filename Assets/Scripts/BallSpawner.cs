using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
  

   public bool NoAttack = false;

    [SerializeField]
    float Timefornextball=5;

    [SerializeField]
    Transform SpawnPoint;

    [SerializeField]
    GameObject Ball;

    [SerializeField]
    float ballVelocitiy=5;
    void Start()
    {
        StartCoroutine(ChangeRotation(Timefornextball));
    }

   


    IEnumerator ChangeRotation(float timer)
    {
        if (NoAttack)
            yield break;

        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.up, Random.Range(-60, 60));
        transform.Rotate(Vector3.forward, Random.Range(30, 60));
        // x = Random.Range(-60, 61);
        // z = Random.Range(-60, 61);

        //  transform.parent.Rotate(new Vector3(x, 0, z), Space.World);

        GameObject go = Instantiate(Ball, SpawnPoint);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward*ballVelocitiy;

        yield return new WaitForSeconds(timer);
        StartCoroutine(ChangeRotation(Timefornextball));
    }
}
