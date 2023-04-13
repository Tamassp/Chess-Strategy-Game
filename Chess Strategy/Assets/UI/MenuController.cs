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

        level1Button.clicked += () => Level1Start();
    }

    private void Level1Start()
    {
        print("MenuController");
        _gameController.Level1Start();
    }
}
