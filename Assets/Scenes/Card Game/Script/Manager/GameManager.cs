using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : PersistenceSingleton<GameManager>
{
    public PlayerManager Player1;
    public PlayerManager Player2;

    protected override void Awake()
    {

    }
    void Start()
    {
        StartCoroutine(nameof(WaitForRegister));
        Setup();
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
    void Setup()
    {
        for (int i = 0; i < 5 ;i++)
        {

        }
    }
    void LoadPlayerMonster()
    {
        
    }
    public void DrawCard()
    {
        Player1.DrawCard();
        Player2.DrawCard();
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

