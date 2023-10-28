using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "MonsterAbility/Aquatic1Tail1/Skill")]
public class Aquatic1Tail1_Skill : MonsterSkill
{
    private PlayerManager m_cacheManager;
    public int m_turnCounter;
    private UnityAction<PlayerAuthority> OnTurnChangeAction;
    public Aquatic1Tail1_Skill()
    {
        SkillDescription = "Deal 2 damage, and draw an additional card when the player turn end";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        base.OnUse(target, user, player);
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage);
        if (m_turnCounter > 0)
        {
            m_turnCounter = 1;
        }
        m_cacheManager = player;
        m_turnCounter = 1;
        TurnManager.Instance.AddEndOfTurnListener(OnTurnChangeAction);

    }
    public void OnTurnChange(PlayerAuthority authority)
    {
        if (authority != m_cacheManager.ThisAuthority)
        {
            return;
        }
        if (m_turnCounter <= 0)
        {
            TurnManager.Instance.RemoveEndOfTurnListener(OnTurnChangeAction);
            return;
        }
        else
        {
            m_cacheManager.DrawCard();
            m_turnCounter--;
        }
    }
}