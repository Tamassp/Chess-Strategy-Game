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
    private Label enemies, pieces, levelLabel, goldLabel;


    private int positionOffsetXPawn = 0;
    private int positionOffsetXKnight = 0;
    private int positionOffsetXBishop = 0;
    private int positionOffsetXRook = 0;
    
    //Event listener
    //private int gold = GameController.gold;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        levelLabel = root.Q<Label>("CurrentLevelLabel");
        levelLabel.text = GameController.currentLevel.Remove(GameController.currentLevel.Length - 7);

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
        
        buttonPawn.SetEnabled(false);
        buttonKnight.SetEnabled(false);
        buttonBishop.SetEnabled(false);
        buttonRook.SetEnabled(false);

        if (_gameController.getCompletedLevels() > 1)
        {
            buttonPawn.SetEnabled(true);
        }
        if (_gameController.getCompletedLevels() > 2)
        {
            buttonKnight.SetEnabled(true);
        }
        if (_gameController.getCompletedLevels() > 3)
        {
            buttonBishop.SetEnabled(true);
        }
        //Under construction
        if (_gameController.getCompletedLevels() > 4)
        {
            buttonRook.SetEnabled(true);
        }
        

        buttonExitLevel.clicked += () => ExitLevel();

        enemies = root.Q<Label>("EnemiesValue");
        pieces = root.Q<Label>("FriendsValue");

        //GameController.
    }

    private void Update()
    {
        enemies.text = GameController.enemyCount.ToString();
        pieces.text = GameController.pieceCount.ToString();
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
            //creating new pieces as part of the level prefab
            GameObject newPawn = Instantiate(pawnPrefab, new Vector3(-30, 0, -48), Quaternion.identity, GameObject.Find(GameController.currentLevel).transform);
            newPawn.tag = "Piece";
            newPawn.GetComponent<NavMesh>().SetDestination(new Vector3(-30 + positionOffsetXPawn, 0, -30));
            positionOffsetXPawn+=2;
            //Update with event listener
            GameController.gold--;
            goldLabel.text = GameController.gold.ToString();

            GameController.pieceCount++;
            pieces.text = GameController.pieceCount.ToString();
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
            GameObject newKnight = Instantiate(knightPrefab, new Vector3(-20, 0, -45), Quaternion.identity, GameObject.Find(GameController.currentLevel).transform);
            newKnight.tag = "Piece";
            newKnight.GetComponent<NavMesh>().SetDestination(new Vector3(-20 + positionOffsetXKnight, 0, -35));
            positionOffsetXKnight+=4;
            
            GameController.gold -= 2;
            goldLabel.text = GameController.gold.ToString();
            
            GameController.pieceCount++;
            pieces.text = GameController.pieceCount.ToString();
        }
    }
    private void BishopSpawn()
    {
        if (GameController.gold >= 2)
        {
            GameObject newBishop = Instantiate(bishopPrefab, new Vector3(20, 0, -48), Quaternion.identity, GameObject.Find(GameController.currentLevel).transform);
            newBishop.tag = "Piece";
            newBishop.GetComponent<NavMesh>().SetDestination(new Vector3(20 + positionOffsetXBishop, 0, -30));
            positionOffsetXBishop+=4;
            
            GameController.gold -= 2;
            goldLabel.text = GameController.gold.ToString();
            
            GameController.pieceCount++;
            pieces.text = GameController.pieceCount.ToString();
        }
    }

    private void RookSpawn()
    {
        if (GameController.gold >= 5)
        {
            GameObject newRook = Instantiate(rookPrefab, new Vector3(30, 0, -48), Quaternion.identity, GameObject.Find(GameController.currentLevel).transform);
            newRook.tag = "Piece";
            newRook.GetComponent<NavMesh>().SetDestination(new Vector3(30 + positionOffsetXRook, 0, -35));
            positionOffsetXRook+=3;
            
            GameController.gold -= 5;
            goldLabel.text = GameController.gold.ToString();
            
            GameController.pieceCount++;
            pieces.text = GameController.pieceCount.ToString();
        }
    }
}
