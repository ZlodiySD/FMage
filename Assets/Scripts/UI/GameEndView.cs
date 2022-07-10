using UnityEngine.UI;

public class GameEndView : View
{
    public Button btnRetry;
    public Button btnMain;

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClicked);
        btnMain.onClick.AddListener(OnMainClick);
    }

    private void OnMainClick()
    {
        uiManager.ShowMainMenu();
    }

    private void OnRetryClicked()
    {
        uiManager.RetryLevel();
    }
}
