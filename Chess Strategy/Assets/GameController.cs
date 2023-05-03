using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public static int enemyCount;
    public static string currentLevel = " ";

    public static string popupTitle = " ";
    public static string popupDescription = " ";

    public static int gold = 0;
    
    private GameObject menuUIDocument;
    private GameObject uIDocument;
    private GameObject popupDocument;

    public GameObject tutorial1Prefab;
    public GameObject tutorial2Prefab;
    public GameObject level1Prefab;
    public GameObject level2Prefab;

    public LevelData tutorial1Data;
    public LevelData tutorial2Data;
    public LevelData level1Data;
    public LevelData level2Data;

    private bool menuIsActive = true;

    //TEST
    private LevelData data;
    
    private void Awake()
    {
        menuUIDocument = gameObject.transform.GetChild (0).gameObject;
        uIDocument = gameObject.transform.GetChild (1).gameObject;
        popupDocument = gameObject.transform.GetChild (2).gameObject;
    }

    public void setEnemyCount(int n)
    {
        enemyCount = n;
    }

    public void decreaseEnemyCount()
    {
        enemyCount--;
    }

    private void OpenPopup(LevelData data)
    {
        popupTitle = data.levelName;
        popupDescription = data.description;
        popupDocument.SetActive(true);
    }

    public void OnPopupAccept()
    {
        popupDocument.SetActive(false);
        GameObject currentPrefab;
        switch(currentLevel) 
        {
            case "Tutorial 1(Clone)":
                currentPrefab = tutorial1Prefab;
                break;
            case "Tutorial 2(Clone)":
                currentPrefab = tutorial2Prefab;
                break;
            case "Level1(Clone)":
                currentPrefab = level1Prefab;
                break;
            case "Level2(Clone)" :
                currentPrefab = level2Prefab;
                break;
            default:
                //Change this to an error prefab
                currentPrefab = tutorial1Prefab;
                break;
        }
        LevelInit(currentPrefab);
    }

    private void LevelInit(GameObject levelPrefab)
    {
        uIDocument.SetActive(true);

        //Setting the parent of the element and instantiating
        Instantiate(levelPrefab, GameObject.Find("GameController").transform, true);
        

        int numberOfEnemies = Helpers.returnNumberOfGameObjectsWithTag("Enemy");
        if(numberOfEnemies != 0)
            enemyCount = numberOfEnemies;
        menuIsActive = false;
    }

    public void Tutorial1Start()
    {
        currentLevel = "Tutorial 1(Clone)";
        menuUIDocument.SetActive(false);
        OpenPopup(tutorial1Data);
    }
    
    public void Tutorial2Start()
    {
        currentLevel = "Tutorial 2(Clone)";
        menuUIDocument.SetActive(false);
        OpenPopup(tutorial2Data);
    }

    public void Level1Start()
    {
        currentLevel = "Level1(Clone)";
        menuUIDocument.SetActive(false);
        OpenPopup(level1Data);
        gold = 15;
    }
    
    public void Level2Start()
    {
        currentLevel = "Level2(Clone)";
        menuUIDocument.SetActive(false);
        OpenPopup(level2Data);
        gold = 20;
    }

    public void LevelClose()
    {
        //In Unity the hierarchy information is stored in the transform property,
        //instead of the Gameobject itself
        GameObject cLevel = gameObject.transform.Find(currentLevel).gameObject;
        uIDocument.SetActive(false);
        menuUIDocument.SetActive(true);
        Destroy(cLevel);
        menuIsActive = true;
        gold = 0;
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
