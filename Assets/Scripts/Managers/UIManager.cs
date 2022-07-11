using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    public List<View> views;

    private View activeView;

    private string LevelTimel;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        InitViews();
    }

    public View GetActiveView() => activeView;

    public string GetLevelTime() => LevelTimel;

    public void ShowMainMenu()
    {
        GameManager.Instance.MainMenu();
        SetActiveView("Main");
    }

    public LevelResultData GetLevelResult() => GameManager.Instance.GetLevelResultData();


    public void RetryLevel()
    {
        GameManager.Instance.RestartLevel();
        HideActiveView();
    }

    private void InitViews()
    {
        foreach (var view in views)
        {
            view.Init(this);
            view.Hide();
        }

        //List<LevelData> data = GameManager.Instance.GetLevelsData();
        //var levelSelectVew = (LevelSelectView)GetView("LevelSelect");
        //levelSelectVew.Init(data);
    }

    public void NextLevel()
    {
        HideActiveView();
        GameManager.Instance.NextLevel();
    }

    public void PlayLastLevel()
    {
        HideActiveView();
        GameManager.Instance.PlayLastLevel();
    }

    public void ShowSelectLevel()
    {
        SetActiveView("SelectLevel");
    }

    public void ShowCredits()
    {
        SetActiveView("Credits");
    }

    public View GetView(string viewName)
    {
        return views.First(x => x.viewName.Equals(viewName));
    }

    public void SetActiveView(string viewName)
    {
        SetActiveView(GetView(viewName));
    }

    public void SetActiveView(View view)
    {
        HideActiveView();

        activeView = view;
        activeView.Show();
    }

    public void HideActiveView()
    {
        if (activeView)
            activeView.Hide();
    }

    public void DisplayTime(TimeSpan time)
    {
        string str = time.ToString(@"mm\:ss\:fff");

        LevelTimel = str;
    }
}
