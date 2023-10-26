using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard : Card
{
    [SerializeField] private SpellCardSOData m_data;

    #region Attribute
    [SerializeField] private bool m_isFastAction;
    public bool IsFastAction {get {return m_isFastAction;}}
    [SerializeField] private MonsterTrait m_mainType;
    public MonsterTrait MainType {get {return MainType;}}
    [SerializeField] private MonsterClass m_mainClass;
    public MonsterClass MainClass {get {return m_mainClass;}}
    [SerializeField] private int m_mainTypeEnergyCost;
    public int MainTypeEnergyCost {get {return m_mainTypeEnergyCost;} set {m_mainTypeEnergyCost = value;}}
    [SerializeField] private int m_otherTypeEnergyCost;
    public int OtherTypeEnergyCost {get {return m_otherTypeEnergyCost;} set {m_otherTypeEnergyCost = value;}}

    #endregion
    public void UseSelf(MonsterCard target)
    {
        m_data.Spell(target, this.gameObject);
    }
    public void UseSelf()
    {
        m_data.Spell(this.gameObject);
    }
    public void RequestEndCardEffect()
    {
        m_data.RequestEndCardEffect(this as SpellCard);
    }
    void Awake()
    {
        InitData();
    }
    void OnValidate()
    {
        m_data.MainClass = m_mainClass;
        m_data.MainType = m_mainType;
        m_data.MainTypeEnergyCost = m_mainTypeEnergyCost;
        m_data.OtherTypeEnergyCost =  m_otherTypeEnergyCost;
        m_data.IsFastAction = m_isFastAction;

        m_data.FrontSprite = FrontSprite;
        m_data.BackSprite = BackSprite;
        m_data.Name = CardName; 
    }
    void InitData()
    {
        m_mainClass = m_data.MainClass;
        m_mainType = m_data.MainType;
        m_mainTypeEnergyCost = m_data.MainTypeEnergyCost;
        m_otherTypeEnergyCost = m_data.OtherTypeEnergyCost;
        m_isFastAction = m_data.IsFastAction;

        CardID = m_data.CardID;
        FrontSprite = m_data.FrontSprite;
        BackSprite = m_data.BackSprite;
        CardName = m_data.Name; 
    }
}
