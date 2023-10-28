using System.Collections;
using System.Collections.Generic;
using BuffSystem;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterAbility/Aquatic1Tail1/NormalAttack")]
public class Aquatic1Tail1_NormalAttack : MonsterNormalAttack
{
    public Aquatic1Tail1_NormalAttack()
    {
        SkillDescription = "perform a Normal Attack that deal 1 damage";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        base.OnUse(target, user, player);
        user.m_component.m_attack.PerformAttack(target, user.NormalAttackDamage);
    }
}