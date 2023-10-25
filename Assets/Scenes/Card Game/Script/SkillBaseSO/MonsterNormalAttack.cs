using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSkill/MonsterNormalAttack")]
public class MonsterNormalAttack : MonsterSkill
{
    [Tooltip("Shouldn't change needTarget value in normal attack to false")]
    //*This shoudlnt be the case in implementation*/
    public MonsterNormalAttack()
    {
        #region Set Default NA Parameter
        SkillName = "Normal Attack";
        SameTypeEnergyCost = 1;
        OtherTypeEnergyCost = 1;
        SkillDescription = "Attack";
        
        NeedTarget = true;
        
        #endregion
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage);
    }
}
