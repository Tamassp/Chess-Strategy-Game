using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int enemyCount;
    private string currentLevel;
    private GameObject menuUIDocument;
    private GameObject uIDocument;

    public GameObject level1Prefab;
    
    private void Awake()
    {
        menuUIDocument = gameObject.transform.GetChild (0).gameObject;
        uIDocument = gameObject.transform.GetChild (1).gameObject;
    }

    public void setEnemyCount(int n)
    {
        enemyCount = n;
    }

    public void decreaseEnemyCount()
    {
        enemyCount--;
    }

    public void Level1Start()
    {
        print("Gamecontroller");
        // GameObject  MenuUIDocument = gameObject.transform.GetChild (0).gameObject;
        // GameObject  UIDocument = gameObject.transform.GetChild (1).gameObject;
        
        menuUIDocument.SetActive(false);
        uIDocument.SetActive(true);
        
        GameObject  level1 = gameObject.transform.GetChild (3).gameObject;
        level1.SetActive(true);
        currentLevel = "Level1";

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
        enemyCount = numberOfEnemies;
    }
    
    public void Level2Start()
    {
        menuUIDocument.SetActive(false);
        uIDocument.SetActive(true);
        
        GameObject  level2 = gameObject.transform.GetChild (4).gameObject;
        level2.SetActive(true);
        currentLevel = "Level2";

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
            enemyCount = numberOfEnemies;
    }

    public void LevelClose(string _currentLevel)
    {
        //In Unity the hierarchy information is stored in the transform property,
        //instead of the Gameobject itself
        GameObject currentLevel = gameObject.transform.Find(_currentLevel).gameObject;
        currentLevel.SetActive(false);
        print(uIDocument + " +++ " + menuUIDocument);
        uIDocument.SetActive(false);
        menuUIDocument.SetActive(true);
        Destroy(currentLevel);
        GameObject level1 = Instantiate(level1Prefab);
        
        level1.transform.parent = GameObject.Find("GameController").transform;
        level1.SetActive(false);
    }
    

    private void Update()
    {
        if (enemyCount == 0)
        {
            print("LEVELCLOSE");
            LevelClose(currentLevel);
            enemyCount = -1;
        }
    }
}
