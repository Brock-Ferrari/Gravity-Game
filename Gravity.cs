using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //What needs to be "fetched"
    // 1) Size of the object with script.
    //      This will allow for different gravity magnitudes based on scale of "planet".
    //      float sizeObj = GetComponent<Collider>().bounds.size.sqrMagnitude;
    // 2) Detect other rigidbodys with a specific tag that labels them as projectiles. 

    public float gravitationalConstant = 10f;
    public float sizeMultiplier = 2f;
    public GameObject deathExplosion;
    public float dragCoefficient;
    public float velocityCap;

    private void Update()
    {
        float sizeObj = GetComponent<Collider>().bounds.size.sqrMagnitude * sizeMultiplier;

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject projectile in projectiles)
        {
            float sizeProjectile = projectile.GetComponent<Collider>().bounds.size.sqrMagnitude;
            Vector3 gravityDirection = (gameObject.transform.position - projectile.transform.position);
            float gravityDistance = gravityDirection.sqrMagnitude;
            Vector3 gravityVector = gravityDirection * gravitationalConstant * sizeObj * sizeProjectile / (gravityDistance * gravityDistance);
                projectile.GetComponent<Rigidbody>().AddForce(gravityVector);
        }

        GameObject[] aimProjectiles = GameObject.FindGameObjectsWithTag("Aim Projectile");
        foreach (GameObject aimProjectile in aimProjectiles)
        {
            float sizeProjectile = aimProjectile.GetComponent<Collider>().bounds.size.sqrMagnitude;
            Vector3 gravityDirection = (gameObject.transform.position - aimProjectile.transform.position);
            float gravityDistance = gravityDirection.sqrMagnitude;
            Vector3 gravityVector = gravityDirection * gravitationalConstant * sizeObj * sizeProjectile / (gravityDistance * gravityDistance);
            aimProjectile.GetComponent<Rigidbody>().AddForce(gravityVector);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Projectile")
        {
            collision.gameObject.GetComponent<Rigidbody>().drag = 100000f;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(collision.gameObject, 1f);
            Instantiate(deathExplosion,collision.transform.position,collision.transform.rotation);
        }
    }

}