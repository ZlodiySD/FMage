using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MoveController moveController;

    [SerializeField]
    private PlayerConfigs playerConfigs;

    private void Awake()
    {
        SetConfigs();
    }

    public void SetConfigs()
    {
        moveController.SetConfig(playerConfigs.moveConfig);
    }

    void FixedUpdate()
    {
        GetMoveIput();
    }

    private void GetMoveIput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        bool isJump = Input.GetAxis("Jump") > 0;

        if (horizontal != 0)
        {
            moveController.Move(horizontal, isJump);
        }
    }
}
