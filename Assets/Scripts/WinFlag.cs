using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WinFlag : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryTriggerWin(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryTriggerWin(collision.gameObject);
    }

    public void TryTriggerWin(GameObject go)
    {
        if(go.TryGetComponent(out PlayerController playerController))
        {
            TriggerWin();
        }
    }

    public void TriggerWin()
    {
        GameManager.Instance.LevelEnd();
    }
}
