using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSkill/MonsterNormalAttack")]
public class MonsterNormalAttack : MonsterSkill
{
    public MonsterNormalAttack()
    {
        #region Set Default NA Parameter
        SkillName = "Normal Attack";
        SameTypeEnergyCost = 1;
        OtherTypeEnergyCost = 1;
        SkillDescription = "Attack";
        #endregion
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage);
    }
}
