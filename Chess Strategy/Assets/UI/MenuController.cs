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

        Button tutorial1Button = root.Q<Button>("Tutorial1Button");
        Button level1Button = root.Q<Button>("Level1Button");
        Button level2Button = root.Q<Button>("Level2Button");

        tutorial1Button.clicked += () => Tutorial1Start();
        level1Button.clicked += () => Level1Start();
        level2Button.clicked += () => Level2Start();
    }

    private void Tutorial1Start()
    {
        _gameController.Tutorial1Start(); 
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
