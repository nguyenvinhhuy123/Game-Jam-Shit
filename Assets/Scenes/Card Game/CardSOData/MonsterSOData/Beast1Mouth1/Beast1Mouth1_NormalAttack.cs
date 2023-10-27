using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterAbility/Beast1Mouth1/NormalAttack")]
public class Beast1Mouth1_NormalAttack : MonsterNormalAttack
{

    public Beast1Mouth1_NormalAttack()
    {
        SkillDescription = "Perform a Normal Attack that deal 2 damage";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        base.OnUse(target, user, player);
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage);
    }
}
