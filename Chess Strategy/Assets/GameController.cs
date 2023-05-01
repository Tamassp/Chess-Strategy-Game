using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int enemyCount;
    public static string currentLevel = " ";
    private GameObject menuUIDocument;
    private GameObject uIDocument;

    public GameObject tutorial1Prefab;
    public GameObject level1Prefab;
    public GameObject level2Prefab;

    private bool menuIsActive = true;
    
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

    public void Tutorial1Start()
    {
        currentLevel = "Tutorial 1(Clone)";
        
        menuUIDocument.SetActive(false);
        uIDocument.SetActive(true);
        
        Instantiate(tutorial1Prefab, GameObject.Find("GameController").transform, true);

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
            enemyCount = numberOfEnemies;
        menuIsActive = false;
    }

    public void Level1Start()
    {
        currentLevel = "Level1(Clone)";
        
        menuUIDocument.SetActive(false);
        uIDocument.SetActive(true);

        //Setting the parent of the element and instantiating
        Instantiate(level1Prefab, GameObject.Find("GameController").transform, true);
        

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
        enemyCount = numberOfEnemies;
        menuIsActive = false;
    }
    
    public void Level2Start()
    {
        currentLevel = "Level2(Clone)";
        menuUIDocument.SetActive(false);
        uIDocument.SetActive(true);
        
        // GameObject  level2 = gameObject.transform.GetChild (4).gameObject;
        // level2.SetActive(true);
        Instantiate(level2Prefab, GameObject.Find("GameController").transform, true);
        

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
            enemyCount = numberOfEnemies;
        menuIsActive = false;
    }

    public void LevelClose()
    {
        //In Unity the hierarchy information is stored in the transform property,
        //instead of the Gameobject itself
        GameObject cLevel = gameObject.transform.Find(currentLevel).gameObject;
        //currentLevel.SetActive(false);
        //print(uIDocument + " +++ " + menuUIDocument);
        uIDocument.SetActive(false);
        menuUIDocument.SetActive(true);
        Destroy(cLevel);
        menuIsActive = true;

        // //Setting the parent of the element and instantiating
        // GameObject level1 = Instantiate(level1Prefab, GameObject.Find("GameController").transform, true);
        // level1.SetActive(false);
    }
    

    private void Update()
    {
        if (enemyCount == 0 && !menuIsActive) 
        {
            print("LEVELCLOSE");
            LevelClose();
            enemyCount = -1;
        }
    }
}
