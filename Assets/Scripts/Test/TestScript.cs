using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
#if UNITY_EDITOR

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnGUI()
    {
        var reloadConfigText = "Reload Player Config";

        GUIContent content = new GUIContent(reloadConfigText);

        GUIStyle style = GUI.skin.button;
        style.alignment = TextAnchor.MiddleCenter;

        Vector2 size = style.CalcSize(content);

        if (GUI.Button(new Rect(50, 25, size.x, size.y), reloadConfigText))
        {
            FindObjectOfType<PlayerController>().SetConfigs();
        }
    }
#endif
}
