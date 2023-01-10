using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject aimProjectile;
    [SerializeField] GameObject fireLocation;
    [SerializeField] float _interval = 1f;
    public GameObject slider;
    public float fireSpeed = 10f;
    public float fireSpeedCorrection = .01f;
    public float shotDelay = 2f;
    public float nextFire = 0f;
    public float currentFire = 0f;
    public Slider delayTimer;
    public GameObject delayTimerImage;
    float _time;
    public GameObject laserShot;
    public float pitchCorrection;

    private void Start()
    {
        delayTimer.maxValue = shotDelay;
        currentFire = -shotDelay;
        _time = 0f;
    }


    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.LookAt(raycastHit.point);
            Vector3 fireDirection = gameObject.transform.position - raycastHit.point;
            fireSpeed = fireDirection.magnitude * fireSpeedCorrection;
            _time += Time.deltaTime;
            while (_time >= _interval)
            {
                CannonAim(fireSpeed);
                _time -= _interval;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            delayTimerImage.SetActive(true);
            nextFire = Time.time + shotDelay;
            FireCannon(fireSpeed);
            currentFire = Time.time;
        }

        delayTimer.value = Time.time - currentFire;
        if (delayTimer.value >= delayTimer.maxValue)
        {
            delayTimerImage.SetActive(false);
        }

        laserShot.GetComponent<AudioSource>().pitch = (fireSpeed / pitchCorrection) + 0.5f;
    }

    public void FireCannon(float fireSpeed)
    {
        GameObject clone = Instantiate(projectile, fireLocation.transform.position, fireLocation.transform.rotation);
        clone.GetComponent<Rigidbody>().velocity = transform.forward * fireSpeed;
        laserShot.SetActive(true);
        Invoke("LaserDelay", shotDelay);
    }
    public void CannonAim(float fireSpeed)
    {
        GameObject clone = Instantiate(aimProjectile, fireLocation.transform.position, fireLocation.transform.rotation);
        clone.GetComponent<Rigidbody>().velocity = transform.forward * fireSpeed;
    }

    public void LaserDelay()
    {
        laserShot.SetActive(false);
    }
}