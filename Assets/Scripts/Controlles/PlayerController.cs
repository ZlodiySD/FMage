using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public MoveController moveController;

    public SphereHolder sphereHolder;
    public PlayerBuffs playerBuffs;
    public SphereHolderIndicator indicatorPrefab;

    [SerializeField]
    private PlayerConfigs playerConfigs;

    private SpellCaster spellCaster;

    private bool isJump;

    private SphereHolderIndicator indicator;

    public AudioSource audioSource;

    private void Awake()
    {
        SetConfigs();
        playerBuffs = new PlayerBuffs();
        sphereHolder.SphereCountMaxed += SphereHolder_SphereCountMaxed;
    }

    private void Start()
    {
        CheckIndicator();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.Play)
            return;

        GetMoveIput();
        GetCastInput();
    }

    public PlayerConfigs GetConfigs() => playerConfigs;

    public void SetGravityScale(float gravityScale)
    {
        moveController._rigidbody.gravityScale = gravityScale;
    }

    public void Die()
    {
        GameManager.Instance.OnPlayerDeath();
    }

    public void ResetGravityScale()
    {
        moveController._rigidbody.gravityScale = playerConfigs.moveConfig.GravityScale;
    }

    private void SphereHolder_SphereCountMaxed(MagicSphereConfig obj)
    {
        Die();
    }

    public void SetConfigs()
    {
        moveController.SetConfig(playerConfigs.moveConfig);

        sphereHolder.SetConfig(playerConfigs.spellsHolderConfig);

        spellCaster = new SpellCaster(sphereHolder);
    }

    private void CheckIndicator()
    {
        indicator = Instantiate(indicatorPrefab);
        indicator.Init(sphereHolder);
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
        {
            moveController.PerformJump();
            AudioManager.Instance.PlayClipFromSource(audioSource, "jump");
        }
    }
}