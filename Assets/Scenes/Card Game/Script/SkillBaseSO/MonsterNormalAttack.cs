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
        EnergyCost = 2;
        SkillDescription = "Attack";
        #endregion
    }
    public override void OnUse(MonsterCard target, MonsterCard user)
    {
        target.DamageSelf(user.NormalAttackDamage);
    }
}
