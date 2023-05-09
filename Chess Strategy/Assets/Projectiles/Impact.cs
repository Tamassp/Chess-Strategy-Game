using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Impact : MonoBehaviour
{
    void OnEnable()
    {
        Invoke ("Destroy", 1.2f);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Piece") )
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
