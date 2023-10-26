using System.Collections;
using System.Collections.Generic;
using BuffSystem;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SpellData/TestSpell1")]
public class TestSpell1 : SpellCardSOData
{
    private NABuffBaseSOData m_NABuffSOData;
    private NABuffHandler m_NABUffHandler;
    [SerializeField] private int m_duration;
    [SerializeField] private LifeTimeType m_lifeTimeType;
    [SerializeField] private int m_NABuffAmount;
    [SerializeField] private StackConditionType m_stackConditionType;
    private MonsterCard m_cacheTarget;
    public override void Spell(MonsterCard target, GameObject caller)
    {
        if (m_NABUffHandler != null)
        {
            Debug.Log("Shouldn't be here, a Spell Card shoudnt cast it spell 2 time");
            //*Shouldnt be here, but this is helpful for testing
            m_cacheTarget.RequestEndOfEffect(caller.gameObject, m_NABUffHandler as BuffHandler);
        }
        m_NABuffSOData = NABuffBaseSOData.CreateInstance<NABuffBaseSOData>();
        m_NABUffHandler = m_NABuffSOData.InitHandler(target, caller) as NABuffHandler;

        m_NABuffSOData.Duration = m_duration;
        m_NABuffSOData.EndConditionType = m_lifeTimeType;
        m_NABuffSOData.NABuffAmount = m_NABuffAmount;
        m_NABuffSOData.Stacking = m_stackConditionType;

        target.AddBuff(m_NABUffHandler);
        m_cacheTarget = target;
    }
    public override void RequestEndCardEffect(SpellCard caller)
    {
        m_cacheTarget.RequestEndOfEffect(caller.gameObject, m_NABUffHandler as BuffHandler);
    }
}
