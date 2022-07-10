using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooseSceenView : View
{
    public Button btnRetry;

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClick);
    }

    private void OnRetryClick()
    {

    }
}
