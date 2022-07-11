using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<GameState> GameStateChanged;

    public GameState GameState { get; private set; }

    private Timer timer;
    private TimeSpan levelTime;
    public LevelResultComparator levelResultComparator;
    public TeacherMessageChooser messagerRandomizer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartLevel();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
            LevelEnd();
#endif
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        timer = new Timer();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangeGameState(GameState.Play);
    }

    public LevelResultData GetLevelResultData()
    {
        var levelId = SceneManager.GetActiveScene().buildIndex;
        var grade = levelResultComparator.GetLevelGrade(levelId, levelTime.TotalSeconds);

        var msg = messagerRandomizer.GetMessage(grade);

        var data = new LevelResultData()
        {
            grade = grade,
            teacherMessage = msg
        };

        return data;
    }

    public void MainMenu()
    {
        ChangeGameState(GameState.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void PlayLastLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ChangeGameState(GameState.Play);
    }

    public void ChangeGameState(GameState state)
    {
        if (state == GameState)
            return;

        GameState = state;
        switch (state)
        {
            case GameState.Play:
                Time.timeScale = 1;
                break;
            case GameState.Stop:
                Time.timeScale = 0; 
                break;
        }

        GameStateChanged?.Invoke(GameState);
    }

    public void OnPlayerDeath()
    {
        ChangeGameState(GameState.Stop);

        AudioManager.Instance.PlayClip("death");
        UIManager.Instance.SetActiveView("LooseScreen");
    }

    public List<LevelData> GetLevelsData()
    {
        return null;
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }

    public void LevelEnd()
    {
        ChangeGameState(GameState.Stop);

        AudioManager.Instance.PlayClip("stone move 1");

        levelTime = timer.StopTimer();
        UIManager.Instance.DisplayTime(levelTime);

        UIManager.Instance.SetActiveView("LevelEnd");
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            UIManager.Instance.SetActiveView("GameEnd");
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ChangeGameState(GameState.Play);
    }
}