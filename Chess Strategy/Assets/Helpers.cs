using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class Helpers
{
    public static int returnNumberOfGameObjectsWithTag(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        return gos.Length;
    }

    public static GameObject[] getAllPieces()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Piece");
        return gos;
    }
}
