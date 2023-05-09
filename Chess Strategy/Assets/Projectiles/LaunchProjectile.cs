using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public float launchAngle = 1;
    public float reloadTime = 1.0f;
    private bool isReloading = false;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!isReloading)
        {
            if (transform.parent.CompareTag("Piece") && collider.gameObject.CompareTag("Enemy") ||
                transform.parent.CompareTag("Enemy") && collider.gameObject.CompareTag("Piece"))
            {
                float x = collider.gameObject.transform.position.x - gameObject.transform.position.x;
                float z = collider.gameObject.transform.position.z - gameObject.transform.position.z;
                GameObject ball = Instantiate(projectile, transform.position, new Quaternion());
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                    (x * 100, launchVelocity, z * 100));
                isReloading = true;
                Invoke("Reload", reloadTime);

                if(source)
                source.Play();
            }
        }
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown("space"))
    //     {
    //         GameObject ball = Instantiate(projectile, transform.position,
    //             transform.rotation);
    //         ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
    //             (0, launchVelocity, launchVelocity));
    //     }
    // }

    void Reload()
    {
        isReloading = false;
    }

}
