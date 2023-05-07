using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public GameController _gameController;

    // private int completedLevels;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button tutorial1Button = root.Q<Button>("Tutorial1Button");
        Button tutorial2Button = root.Q<Button>("Tutorial2Button");
        Button level1Button = root.Q<Button>("Level1Button");
        Button level2Button = root.Q<Button>("Level2Button");
        Button level3Button = root.Q<Button>("Level3Button");
        Button level4Button = root.Q<Button>("Level4Button");

        tutorial1Button.clicked += () => Tutorial1Start();
        tutorial2Button.clicked += () => Tutorial2Start();
        level1Button.clicked += () => Level1Start();
        level2Button.clicked += () => Level2Start();
        level3Button.clicked += () => Level3Start();

        tutorial2Button.SetEnabled(false);
        level1Button.SetEnabled(false);
        level2Button.SetEnabled(false);
        level3Button.SetEnabled(false);
        level4Button.SetEnabled(false);
        
        if (_gameController.getCompletedLevels() > 0)
        {
            tutorial2Button.SetEnabled(true);
        }
        
        if (_gameController.getCompletedLevels() > 1)
        {
            level1Button.SetEnabled(true);
        }

        if (_gameController.getCompletedLevels() > 2)
        {
            level2Button.SetEnabled(true);
        }
        
        if (_gameController.getCompletedLevels() > 3)
        {
            level3Button.SetEnabled(true);
        }
    }


    // public void LoadData(GameData data)
    // {
    //     this.completedLevels = data.completedLevels;
    //     print("Levels" + this.completedLevels);
    // }
    //
    // public void SaveData(ref GameData data)
    // {
    //     data.completedLevels = this.completedLevels;
    // }
    
    private void Tutorial1Start()
    {
        _gameController.Tutorial1Start(); 
    }
    
    private void Tutorial2Start()
    {
        _gameController.Tutorial2Start(); 
    }

    private void Level1Start()
    {
        _gameController.Level1Start();
    }
    private void Level2Start()
    {
        _gameController.Level2Start();
    }
    private void Level3Start()
    {
        _gameController.Level3Start();
    }

}
