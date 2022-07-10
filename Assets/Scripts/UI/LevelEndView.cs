using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelEndView : View
{
    public Button btnNextLevel;
    public Button btnRetry;
    public Button btnMain;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI teacherText;

    public Sprite sprFGrade;
    public Sprite sprPassGrade;

    public Image imgGradeHolder;

    private void Awake()
    {
        btnNextLevel.onClick.AddListener(OnNextClicked);
        btnRetry.onClick.AddListener(OnRetryClicked);
        btnMain.onClick.AddListener(OnMainClick);
    }

    public override void Show()
    {
        base.Show();

        imgGradeHolder.gameObject.SetActive(false);
        timeText.text = uiManager.GetLevelTime();

        SetData(uiManager.GetLevelResult());
    }
    
    private void SetData(LevelResultData levelResultData)
    {
        switch (levelResultData.grade)
        {
            case Grade.F:
                imgGradeHolder.sprite = sprFGrade;
                imgGradeHolder.gameObject.SetActive(true);
                break;
            case Grade.Pass:
                imgGradeHolder.sprite = sprPassGrade;
                imgGradeHolder.gameObject.SetActive(true);
                break;
        }

        teacherText.text = levelResultData.teacherMessage;
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