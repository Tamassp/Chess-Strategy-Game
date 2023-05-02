using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupController : MonoBehaviour
{
    public GameController _gameController;
    private Label titleLable, descriptionLabel;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        titleLable = root.Q<Label>("TitleLabel");
        titleLable.text = GameController.popupTitle;
        
        descriptionLabel = root.Q<Label>("DescriptionLabel");
        descriptionLabel.text = GameController.popupDescription;
        
        Button acceptButton = root.Q<Button>("AcceptButton");

        acceptButton.clicked += OnAcceptButtonClick;
    }

    private void OnAcceptButtonClick()
    {
        _gameController.OnPopupAccept();
    }
    

    // public void SetTitle(string title)
    // {
    //     titleLable.text = title;
    // }
    //
    // public void SetDescription(string description)
    // {
    //     descriptionLabel.text = description;
    // }
}
