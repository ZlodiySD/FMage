using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndView : View
{
    public Button btnNextLevel;
    public Button btnRetry;
    public Button btnMain;

    private void Awake()
    {
        btnNextLevel.onClick.AddListener(OnNextClicked);
        btnRetry.onClick.AddListener(OnRetryClicked);
        btnMain.onClick.AddListener(OnMainClick);
    }

    private void OnMainClick()
    {
        uiManager.ShowMainMenu();
    }

    private void OnRetryClicked()
    {
        uiManager.RetryLevel();
    }

    private void OnNextClicked()
    {
        uiManager.NextLevel();
    }
}
