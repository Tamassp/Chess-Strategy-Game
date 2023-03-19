using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag.Equals("Piece") || gameObject.tag.Equals("Enemy"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnDestroy()
    {
        if (gameObject.tag.Equals("Piece") || gameObject.tag.Equals("Enemy"))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
