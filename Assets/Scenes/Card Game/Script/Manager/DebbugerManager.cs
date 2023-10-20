using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DebbugerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public MonsterCard Monster1;
    public MonsterCard Monster2;
    public SpellCard Spell1;

    // Update is called once per frame
    void Start()
    {
        TurnManager.Instance.RequestFirstToMove(PlayerAuthority.PLAYER_1);
    }
    void Update()
    {
        //!for testing with health and attack communication
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int healthMonster2Before = Monster2.m_component.m_health.CurrentHealthValue;
            Monster1.UseNormalAttack(Monster2, null);
            Assert.AreNotEqual(Monster2.m_component.m_health.CurrentHealthValue, healthMonster2Before);
        }

        //!for testing with buff system
        if (Input.GetKeyDown(KeyCode.B))
        {
            int NADamageBefore = Monster1.NormalAttackDamage;
            Spell1.UseSelf(Monster1);
            Assert.AreNotEqual(NADamageBefore, Monster1.NormalAttackDamage);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spell1.RequestEndCardEffect();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnManager.Instance.RequestEndOfTurn(PlayerAuthority.PLAYER_1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnManager.Instance.RequestEndOfTurn(PlayerAuthority.PLAYER_2);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TestHealingEffect();
        }
    }
    void TestHealingEffect()
    {
        int healthBefore = Monster2.m_component.m_health.CurrentHealthValue;
        Monster2.UseSpell(Monster2, null);
        if (healthBefore < Monster2.m_component.m_health.InitHealthValue)
        Assert.AreNotEqual(healthBefore, Monster2.m_component.m_health.CurrentHealthValue);
        else Assert.AreEqual(healthBefore, Monster2.m_component.m_health.CurrentHealthValue);
    }
}
