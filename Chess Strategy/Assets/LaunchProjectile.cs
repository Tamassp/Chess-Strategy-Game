using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    private void OnTriggerEnter(Collider collider)
    {
        //print(collider.gameObject.tag);
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            float x = collider.gameObject.transform.position.x - gameObject.transform.position.x;
            float z = collider.gameObject.transform.position.z - gameObject.transform.position.z;
            print(x +" AND " + gameObject.transform.position.x + "::::"+ z +" AND " + gameObject.transform.position.z);
            print(new Vector3
                (x*100, launchVelocity, z*100));
            GameObject ball = Instantiate(projectile, transform.position,
                transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                (x*100, launchVelocity, z*100));
            print("ENEMY");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject ball = Instantiate(projectile, transform.position,
                transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                (0, launchVelocity, launchVelocity));
        }
    }

}
