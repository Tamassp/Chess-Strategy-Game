using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonImpact : MonoBehaviour
{
    void OnEnable()
    {
        Invoke ("Destroy", 2.0f);
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
