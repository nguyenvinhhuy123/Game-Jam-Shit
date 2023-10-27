using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using BuffSystem;

[CreateAssetMenu(menuName = "MonsterAbility/Beast1Horn1/Skill")]
public class Beast1Horn1_Skill : MonsterSkill
{

    private NABuffBaseSOData m_NABuffSOData;
    private NABuffHandler m_NABUffHandler;
    public int m_NABuffAmount = 3;
    public int m_duration = 1;
    //check for end on external call (when the monster use Normal Attack again after getting the buff)
    private LifeTimeType m_lifeTimeType = LifeTimeType.END_ON_EXTERNAL_CALL;
    // private UnityAction<PlayerAuthority> OnTurnChangeAction;
    public Beast1Horn1_Skill()
    {
        SkillDescription = "Deal 1 Damage, The next Normal Attack will deal an additional of 3 damage";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        user.m_component.m_attack.PerformAttack(target, user.SkillDamage);
        if (m_NABUffHandler == null)
        {
            m_NABuffSOData = NABuffBaseSOData.CreateInstance<NABuffBaseSOData>();
            m_NABUffHandler = m_NABuffSOData.InitHandler(target, caller) as NABuffHandler;
            m_NABuffSOData.Duration = m_duration;
            m_NABuffSOData.EndConditionType = m_lifeTimeType;
            m_NABuffSOData.NABuffAmount = m_NABuffAmount;
            target.AddBuff(m_NABUffHandler);
        }
    }
}