using UnityEngine;

public abstract class View : MonoBehaviour, IView
{
    public string viewName;
    protected UIManager uiManager;

    public void Init(UIManager uiManager) => this.uiManager = uiManager;

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
}