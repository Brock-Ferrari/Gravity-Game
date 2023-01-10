using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{

    public float deathTimer = 2f;
    public float dragCoefficient;
    private void Awake()
    {
        Invoke("KillTrail", deathTimer);
    }

    private void KillTrail()
    {
        gameObject.GetComponent<Rigidbody>().drag = dragCoefficient*Time.time;
        Destroy(gameObject, 1f);
    }

    public void Update()
    {
        //Debug.Log(gameObject.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
