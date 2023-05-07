using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour, IDataPersistence
{
    public static int enemyCount;
    public static int pieceCount;
    public static string currentLevel = " ";

    public static string popupTitle = " ";
    public static string popupDescription = " ";
    
    private int completedLevels;

    public static int gold = 0;
    
    private GameObject menuUIDocument;
    private GameObject uIDocument;
    private GameObject popupDocument;

    public GameObject tutorial1Prefab;
    public GameObject tutorial2Prefab;
    public GameObject level1Prefab;
    public GameObject level2Prefab;
    public GameObject level3Prefab;

    public LevelData tutorial1Data;
    public LevelData tutorial2Data;
    public LevelData level1Data;
    public LevelData level2Data;
    public LevelData level3Data;

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
            case "Level3(Clone)" :
                currentPrefab = level3Prefab;
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
        int numberOfPieces = Helpers.returnNumberOfGameObjectsWithTag("Piece");
        if (numberOfPieces != 0)
        {
            pieceCount = numberOfPieces;
        }
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
        gold = 30;
    }
    
    public void Level2Start()
    {
        currentLevel = "Level2(Clone)";
        menuUIDocument.SetActive(false);
        OpenPopup(level2Data);
        gold = 50;
    }
    
    public void Level3Start()
    {
        currentLevel = "Level3(Clone)";
        print("LEVELL3");
        
        menuUIDocument.SetActive(false);
        OpenPopup(level3Data);
        gold = 40;
    }

    public void LevelClose()
    {
        //In Unity the hierarchy information is stored in the transform property,
        //instead of the Gameobject itself
        print("WHYY");
        GameObject cLevel = gameObject.transform.Find(currentLevel).gameObject;
        uIDocument.SetActive(false);
        Destroy(cLevel);

        //Delete remaining pieces
        // GameObject[] gos = Helpers.getAllPieces();
        // int i = 0;
        // while (gos.Length > 0)
        // {
        //     Destroy(gos[i]);
        // }
        
        
        
        Destroy(cLevel);
        menuIsActive = true;
        gold = 0;

        switch (currentLevel)
        {
            case "Tutorial 1(Clone)":
                if(completedLevels == 0) 
                    completedLevels ++;
                break;
            case "Tutorial 2(Clone)":
                if(completedLevels == 1) 
                    completedLevels ++;
                break;
            case "Level1(Clone)":
                if(completedLevels == 2) 
                    completedLevels ++;
                break;
            case  "Level2(Clone)":
                if(completedLevels == 3) 
                    completedLevels ++;
                break;
        }
        menuUIDocument.SetActive(true);
    }
    

    private void Update()
    {
        if (enemyCount == 0 && !menuIsActive) 
        {
            LevelClose();
            enemyCount = -1;
        }

        if (pieceCount == 0 && gold == 0 && !menuIsActive)
        {
            print("22");
            LevelClose();
        }
    }

    public int getCompletedLevels()
    {
        return completedLevels;
    }
    
    public void LoadData(GameData data)
    {
        this.completedLevels = data.completedLevels;
        print("CL "+ completedLevels);
        menuUIDocument.SetActive(true);
        print("UI???");
    }

    public void SaveData(ref GameData data)
    {
        data.completedLevels = this.completedLevels;
    }
}
