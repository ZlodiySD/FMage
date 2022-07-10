using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    public Button btnPlay;
    public Button btnSelectLevel;
    public Button btnCredits;

    private void Start()
    {
        btnPlay.onClick.AddListener(OnPlayClick);
        btnSelectLevel.onClick.AddListener(OnSelectClick);
        btnCredits.onClick.AddListener(OnCreditsClick);
    }

    private void OnPlayClick()
    {
        uiManager.PlayLastLevel();
    }

    private void OnSelectClick()
    {
        uiManager.ShowSelectLevel();
    }

    private void OnCreditsClick()
    {
        uiManager.ShowCredits();
    }
}
