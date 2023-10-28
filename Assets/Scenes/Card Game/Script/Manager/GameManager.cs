using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : PersistenceSingleton<GameManager>
{
    public PlayerManager Player1;
    public PlayerManager Player2;
    private UnityAction<PlayerAuthority> OnEndOfTurnAction;
    protected override void Awake()
    {
        base.Awake();
    }
    void OnEnable()
    {
        OnEndOfTurnAction += OnEndOfTurn;
    }
    void OnDisable()
    {
        OnEndOfTurnAction -= OnEndOfTurn;
    }
    void Start()
    {
        StartCoroutine(nameof(Setup));
        TurnManager.Instance.AddEndOfTurnListener(OnEndOfTurnAction);
    }
    void OnEndOfTurn(PlayerAuthority AuthorityAfterTurnChange)
    {
        if (AuthorityAfterTurnChange == Player1.ThisAuthority)
        {
            Player1.DrawCard();
            Player1.DrawEnergy();
            Player1.EndThisPhase();
        }
        if (AuthorityAfterTurnChange == Player2.ThisAuthority)
        {
            Player2.DrawCard();
            Player2.DrawEnergy();
            Player2.EndThisPhase();
        }
    }
    IEnumerator WaitForRegister()
    {
        yield return new WaitUntil (() => 
            (
                Player1 != null
                && Player2 != null
            )
        );
    }
    IEnumerator Setup()
    {
        yield return StartCoroutine(nameof(WaitForRegister));
        LoadPlayerMonster();
        for (int i = 0; i < 4 ;i++)
        {
            Debug.Log("Deal 1 card");
            DealCard();
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("Deal 1 energy");
            DealEnergy();
            yield return new WaitForSeconds(0.5f);
        }
        DiceRoll();
    }
    void LoadPlayerMonster()
    {
        Player1?.LoadPlayerMonster();
        Player2?.LoadPlayerMonster();
    }
    public void DiceRoll()
    {
        int player1Dice;
        int player2Dice;

        //TODO: Roll 2 dice to decide who go first
    }
    public void DealCard()
    {
        Player1?.DrawCard();
        Player2?.DrawCard();
    }
    public void DealEnergy()
    {
        Player1?.DrawEnergy();
        Player2?.DrawEnergy();
    }
    public void RegisterPlayer(PlayerManager playerToRegister)
    {
        if (Player1 != null && Player2 != null)
        {
            Debug.Log("Already have 2 player, can not register to play");
            return;
        }
        if (Player1 == null)
        {
            Player1 = playerToRegister;
            Player1.SetAuthority(this, PlayerAuthority.PLAYER_1);
            return;
        }
        if (Player1 != null && Player2 == null)
        {
            if (playerToRegister == Player1)
            {
                Debug.Log("Cannot register 1 player 2 time");
                return;
            }
            Player2 = playerToRegister;
            Player2.SetAuthority(this, PlayerAuthority.PLAYER_2);
            return;
        }
    }
    
}

