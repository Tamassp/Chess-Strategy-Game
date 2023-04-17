using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public GameController _gameController;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button level1Button = root.Q<Button>("Level1Button");
        Button level2Button = root.Q<Button>("Level2Button");

        level1Button.clicked += () => Level1Start();
        level2Button.clicked += () => Level2Start();
    }

    private void Level1Start()
    {
        _gameController.Level1Start();
    }
    private void Level2Start()
    {
        _gameController.Level2Start();
    }
}
