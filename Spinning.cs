using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float spinSpeed;
    public float rotationVector; 

    private void Start()
    {

    }

    private void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = - Time.time * spinSpeed;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
