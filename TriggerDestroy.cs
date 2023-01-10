using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject,1f);
        other.gameObject.GetComponent<Rigidbody>().drag = 1000000000f;
    }
}
