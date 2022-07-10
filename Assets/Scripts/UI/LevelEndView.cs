using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndView : View
{
    public Button btnNextLevel;
    public Button btnRetry;

    private void Awake()
    {
        btnNextLevel.onClick.AddListener(OnNextClicked);
        btnRetry.onClick.AddListener(OnRetryClicked);
    }

    private void OnRetryClicked()
    {

    }

    private void OnNextClicked()
    {

    }
}
