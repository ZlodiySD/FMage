using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState GameState { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartLevel();

        if (Input.GetKeyDown(KeyCode.Escape))
            LevelEnd();
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
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangeGameState(GameState.Play);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLastLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ChangeGameState(GameState.Play);
    }

    public void ChangeGameState(GameState state)
    {
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
    }

    public void OnPlayerDeath()
    {
        ChangeGameState(GameState.Stop);
        UIManager.Instance.SetActiveView("LooseScreen");
    }

    public List<LevelData> GetLevelsData()
    {
        return null;
    }

    public void LevelEnd()
    {
        ChangeGameState(GameState.Stop);

        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            UIManager.Instance.SetActiveView("GameEnd");
            return;
        }

        UIManager.Instance.SetActiveView("LevelEnd");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ChangeGameState(GameState.Play);
    }
}
