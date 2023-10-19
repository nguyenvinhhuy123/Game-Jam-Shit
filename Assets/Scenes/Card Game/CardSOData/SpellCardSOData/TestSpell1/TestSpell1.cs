using System.Collections;
using System.Collections.Generic;
using BuffSystem;
using UnityEngine;

public class TestSpell1 : SpellCardSOData
{
    private NABuffBaseSOData m_NABuffSOData;
    private NABuffHandler m_NABUffHandler;
    public override void Spell(MonsterCard target, GameObject caster)
    {
        m_NABuffSOData = NABuffBaseSOData.CreateInstance<NABuffBaseSOData>();
        m_NABUffHandler = m_NABuffSOData.InitHandler(target, caster) as NABuffHandler;

        m_NABuffSOData.Duration = 3;
        m_NABuffSOData.EndConditionType = LifeTimeType.END_ON_TIME;
        m_NABuffSOData.NABuffAmount = 2;
        m_NABuffSOData.Stacking = StackConditionType.OVERRIDE;

        target.AddBuff(m_NABUffHandler);
    }
}
