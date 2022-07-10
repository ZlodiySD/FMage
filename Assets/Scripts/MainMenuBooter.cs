using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBooter : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.SetActiveView("Main");
    }
}
