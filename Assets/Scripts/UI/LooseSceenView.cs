using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooseSceenView : View
{
    public Button btnRetry;
    public Button btnMain;

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClick);
        btnMain.onClick.AddListener(OnMainClick);
    }

    private void OnMainClick()
    {
        uiManager.ShowMainMenu();
    }

    private void OnRetryClick()
    {
        uiManager.RetryLevel();
    }
}
