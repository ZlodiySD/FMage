using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnGUI()
    {
        var reloadConfigText = "Reload Player Config";

        GUIContent content = new GUIContent(reloadConfigText);

        GUIStyle style = GUI.skin.button;
        style.alignment = TextAnchor.MiddleCenter;

        Vector2 size = style.CalcSize(content);

        if (GUI.Button(new Rect(100,50, size.x, size.y), reloadConfigText))
        {
            FindObjectOfType<PlayerController>().SetConfigs();
        }
    }
#endif
}
