using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public RaycastHit originHit;
    public Vector3 aim;
    public Vector3 startingPoint;
    public Camera trackerCam;
    public float movementFactor = .1f;
    public float movementFactorAdjusted;
    public float maximumCamSpeed;

    public void Start()
    {
        startingPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out originHit);
    }

    public void Update()
    {
        Ray ray = trackerCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            aim = raycastHit.point - originHit.point;
            movementFactorAdjusted = movementFactor * Mathf.Clamp(1/aim.magnitude, 0, maximumCamSpeed);
            aim = new Vector3(aim.x * movementFactorAdjusted, aim.y * movementFactorAdjusted, aim.z);
        }
        gameObject.transform.position = aim + startingPoint;
    }

}
