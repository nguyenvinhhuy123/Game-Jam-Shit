using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MonsterSkill/TestMonster2")]
public class TestMonster2Skill : MonsterSkill
{
    public TestMonster2Skill()
    {
        SkillDescription = "Shield target for 3 health, last 2 turn";
    }
    public override void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        base.OnUse(target, user, player);
        target.m_component.m_health.ShieldSelf(3 , 2);
    }
}
