using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public MoveController moveController;

    public SphereHolder sphereHolder;

    [SerializeField]
    private PlayerConfigs playerConfigs;

    private SpellCaster spellCaster;

    private bool isJump;

    private void Awake()
    {
        SetConfigs();

        sphereHolder.SphereCountMaxed += SphereHolder_SphereCountMaxed;
    }
    public PlayerConfigs GetConfigs() => playerConfigs;

    public void SetGravityScale(float gravityScale)
    {
        moveController._rigidbody.gravityScale = gravityScale;
    }

    public void ResetGravityScale()
    {
        moveController._rigidbody.gravityScale = playerConfigs.moveConfig.GravityScale;
    }

    private void SphereHolder_SphereCountMaxed(MagicSphereConfig obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetConfigs()
    {
        moveController.SetConfig(playerConfigs.moveConfig);

        sphereHolder.SetConfig(playerConfigs.spellsHolderConfig);

        spellCaster = new SpellCaster(sphereHolder);
    }

    void Update()
    {
        GetMoveIput();
        GetCastInput();
    }
    private void GetCastInput()
    {
        if (isJump)
            return;

        bool isSecondaryCast = Input.GetKeyDown(KeyCode.Mouse1);

        if (isSecondaryCast)
            spellCaster.CastSpell(OnSpellCasted);
    }

    private void OnSpellCasted(MagicSphereConfig magicSphereConfig, SpellType spellType)
    {
        sphereHolder.RemoveSphere(magicSphereConfig);
    }

    private void GetMoveIput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        isJump = Input.GetKeyDown(KeyCode.Space);

        if (horizontal != 0)
        {
            moveController.Move(horizontal * playerConfigs.moveConfig.MovementSpeed);
        }
        else
            moveController.Move(0);

        if (isJump)
            moveController.PerformJump();
    }
}