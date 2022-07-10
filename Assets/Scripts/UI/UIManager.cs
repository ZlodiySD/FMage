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

    private void InitViews()
    {
        foreach (var view in views)
            view.Init(this);
    }

    public void PlayLastLevel()
    {
        HideActiveView();
        GameManager.Instance.PlayLastLevel();
    }

    public void ShowSelectLevel()
    {
        SetActiveView(GetView("SelectLevel"));
    }

    public void ShowCredits()
    {
        SetActiveView(GetView("Credits"));
    }

    public View GetView(string viewName)
    {
        return views.First(x => x.name.Equals(viewName));
    }

    public void SetActiveView(View view)
    {
        HideActiveView();

        activeView = view;
    }

    public void HideActiveView()
    {
        if (activeView)
            activeView.Hide();
    }
}