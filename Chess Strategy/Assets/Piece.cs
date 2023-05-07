using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            GameController.enemyCount--;
        }
        if (gameObject.CompareTag("Piece"))
        {
            GameController.pieceCount--;
        }
    }
}
