using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public GameController _gameController;

    public GameObject pawnPrefab;
    public GameObject knightPrefab;
    public GameObject bishopPrefab;
    public GameObject rookPrefab;

    private VisualElement root;
    private Label enemies, levelLabel, goldLabel;
    
    //Event listener
    //private int gold = GameController.gold;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        levelLabel = root.Q<Label>("CurrentLevelLabel");
        levelLabel.text = GameController.currentLevel.Substring(0, 6 );

        goldLabel = root.Q<Label>("GoldValue");
        goldLabel.text = GameController.gold.ToString();
        
        Button buttonPawn = root.Q<Button>("ButtonPawn");
        Button buttonKnight = root.Q<Button>("ButtonKnight");
        Button buttonBishop = root.Q<Button>("ButtonBishop");
        Button buttonRook = root.Q<Button>("ButtonRook");

        Button buttonExitLevel = root.Q<Button>("ExitLevelButton");

        buttonPawn.clicked += () => PawnSpawn();
        buttonKnight.clicked += () => KnightSpawn();
        buttonBishop.clicked += () => BishopSpawn();
        buttonRook.clicked += () => RookSpawn();

        buttonExitLevel.clicked += () => ExitLevel();

        enemies = root.Q<Label>("EnemiesValue");
        
        //GameController.
    }

    private void Update()
    {
        enemies.text = GameController.enemyCount.ToString();
    }

    private void ExitLevel()
    {
        //print(_gameController.name);
        _gameController.LevelClose();
    }

    private void PawnSpawn()
    {
        if (GameController.gold > 0)
        {
            GameObject newPawn = Instantiate(pawnPrefab, new Vector3(-30, 0, -48), Quaternion.identity);
            newPawn.tag = "Piece";
            newPawn.GetComponent<NavMesh>().SetDestination(new Vector3(-30, 0, -30));

            //Update with event listener
            GameController.gold--;
            goldLabel.text = GameController.gold.ToString();
        }
        else
        {
            //NOT ENOUGH GOLD
        }
    }

    private void KnightSpawn()
    {
        if (GameController.gold >= 2)
        {
            GameObject newKnight = Instantiate(knightPrefab, new Vector3(-20, 0, -48), Quaternion.identity);
            newKnight.tag = "Piece";
            newKnight.GetComponent<NavMesh>().SetDestination(new Vector3(-20, 0, -30));
            
            GameController.gold -= 2;
            goldLabel.text = GameController.gold.ToString();
        }
    }
    
    private void BishopSpawn()
    {
        if (GameController.gold >= 2)
        {
            GameObject newBishop = Instantiate(bishopPrefab, new Vector3(20, 0, -48), Quaternion.identity);
            newBishop.tag = "Piece";
            newBishop.GetComponent<NavMesh>().SetDestination(new Vector3(20, 0, -30));
            
            GameController.gold -= 2;
            goldLabel.text = GameController.gold.ToString();
        }
    }

    private void RookSpawn()
    {
        if (GameController.gold >= 5)
        {
            GameObject newRook = Instantiate(rookPrefab, new Vector3(30, 0, -48), Quaternion.identity);
            newRook.tag = "Piece";
            newRook.GetComponent<NavMesh>().SetDestination(new Vector3(30, 0, -30));
            
            GameController.gold -= 5;
            goldLabel.text = GameController.gold.ToString();
        }
    }
}
