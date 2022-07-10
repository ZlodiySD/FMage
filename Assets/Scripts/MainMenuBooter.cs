using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBooter : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ChangeGameState(GameState.MainMenu);
        UIManager.Instance.SetActiveView("Main");
    }
}
