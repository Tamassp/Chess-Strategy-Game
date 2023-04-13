using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public GameObject pawnPrefab;
    public GameObject knightPrefab;
    public GameObject bishopPrefab;
    public GameObject rookPrefab;
    
    private VisualElement root;
    private Label enemies;
    
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonPawn = root.Q<Button>("ButtonPawn");
        Button buttonKnight = root.Q<Button>("ButtonKnight");
        Button buttonBishop = root.Q<Button>("ButtonBishop");
        Button buttonRook = root.Q<Button>("ButtonRook");

        buttonPawn.clicked += () => PawnSpawn();
        buttonKnight.clicked += () => KnightSpawn();
        buttonBishop.clicked += () => BishopSpawn();
        buttonRook.clicked += () => RookSpawn();

        enemies = root.Q<Label>("EnemiesValue");
        //GameController.
        
    }

    private void Update()
    {
        enemies.text = GameController.enemyCount.ToString();
    }

    private void PawnSpawn()
    {
        GameObject newPawn = Instantiate(pawnPrefab, new Vector3(-30, 0, -48), Quaternion.identity);
        newPawn.tag = "Piece";
        newPawn.GetComponent<NavMesh>().SetDestination(new Vector3(-30, 0, -30));
    }

    private void KnightSpawn()
    {
        GameObject newKnight = Instantiate(knightPrefab, new Vector3(-20, 0, -48), Quaternion.identity);
        newKnight.tag = "Piece";
        newKnight.GetComponent<NavMesh>().SetDestination(new Vector3(-20, 0, -30));
    }
    
    private void BishopSpawn()
    {
        GameObject newBishop = Instantiate(bishopPrefab, new Vector3(20, 0, -48), Quaternion.identity);
        newBishop.tag = "Piece";
        newBishop.GetComponent<NavMesh>().SetDestination(new Vector3(20, 0, -30));
    }

    private void RookSpawn()
    {
        GameObject newRook = Instantiate(rookPrefab, new Vector3(30, 0, -48), Quaternion.identity);
        newRook.tag = "Piece";
        newRook.GetComponent<NavMesh>().SetDestination(new Vector3(30, 0, -30));
    }
}
