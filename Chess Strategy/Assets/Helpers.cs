using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static int returnNumberOfGameObjectsWithTag(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        return gos.Length;
    }
}
