using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
    }

    internal void PlayLastLevel()
    {
        throw new NotImplementedException();
    }

    public void OnPlayerDeath()
    {
        //TEST
        RestartLevel();
        //TEST
    }

    public void LevelWin()
    {
        Debug.Log("You win!");

        //TEST
        RestartLevel();
        //TEST
    }
}
