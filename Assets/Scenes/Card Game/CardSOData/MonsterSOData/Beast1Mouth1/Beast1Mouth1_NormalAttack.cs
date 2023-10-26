using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MonsterNormalAttack/Beast1Mouth1")]
public class Beast1Mouth1_Skill : MonsterSkill
{
    
    public Beast1Mouth1_Skill()
    {
        SkillDescription = "perform a Normal Attack that deal 2 damage";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        base.OnUse(target, user, player);
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage)
    }
}
