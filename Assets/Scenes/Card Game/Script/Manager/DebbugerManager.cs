using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DebbugerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerManager Player1;
    public PlayerManager Player2;
    public MonsterCard Monster1;
    public MonsterCard Monster2;
    public SpellCard Spell1;

    // Update is called once per frame
    void Start()
    {
        TurnManager.Instance.RequestFirstToMove(PlayerAuthority.PLAYER_1);
        Player1 = GameObject.Find("Player1Manager")?.GetComponent<PlayerManager>();
        Player2 = GameObject.Find("Player2Manager")?.GetComponent<PlayerManager>();
    }
    void Update()
    {
        //!for testing with health and attack communication
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TestPlayer1UseMonster1Attack();
        }

        //!for testing with buff system
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //Spell1.RequestEndCardEffect();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(GameManager.Instance);
            GameManager.Instance.RegisterPlayer(Player1);
            //TurnManager.Instance.RequestEndOfPhase(PlayerAuthority.PLAYER_1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.RegisterPlayer(Player2);
            //TurnManager.Instance.RequestEndOfPhase(PlayerAuthority.PLAYER_2);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //TestHealingEffect();
        }
    }
    void TestHealingEffect()
    {
        int healthBefore = Monster2.m_component.m_health.CurrentHealthValue;
        Monster2.UseSkill(Monster2, Player2);
        if (healthBefore < Monster2.m_component.m_health.InitHealthValue)
        Assert.AreNotEqual(healthBefore, Monster2.m_component.m_health.CurrentHealthValue);
        else Assert.AreEqual(healthBefore, Monster2.m_component.m_health.CurrentHealthValue);
    }
    void TestPlayer1UseMonster1Attack()
    {
        Monster1.UseNormalAttack(Monster2, Player1);
    }
}
