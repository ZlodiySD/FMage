using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBtnView : MonoBehaviour
{
    public Button btnLevel;

    private int LevelId;
    private string LevelName;
    private bool IsActive;
    private string LevelTime;

    public TextMeshProUGUI levelName;
    public TextMeshProUGUI levelTime;

    private LevelSelectView levelSelectView;

    private void Start()
    {
        btnLevel.onClick.AddListener(OnSelectButtonClick);
    }

    private void OnSelectButtonClick()
    {
        levelSelectView.LevelSelected(LevelId);
    }

    public void Init(LevelSelectView levelSelectView, LevelData data)
    {
        this.levelSelectView = levelSelectView;

        LevelId = data.LevelId;
        LevelName = data.LevelName;
        IsActive = data.IsActive;

        SetButtonActive(IsActive);
    }

    private void SetButtonActive(bool isActive)
    {
        if (isActive)
        {
            levelName.text = LevelName;
            levelTime.text = LevelTime;

        }
        else
        {
            levelName.text = LevelName;
        }
    }
}
