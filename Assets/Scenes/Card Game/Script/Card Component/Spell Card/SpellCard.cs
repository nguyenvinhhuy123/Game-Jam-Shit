using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellCard : Card
{
    [SerializeField] private SpellCardSOData m_data;

    #region Attribute
    [SerializeField] private bool m_isInstance;
    public bool IsInstance { get { return m_isInstance; } }
    [SerializeField] private MonsterTrait m_mainType;
    public MonsterTrait MainType { get { return MainType; } }
    [SerializeField] private MonsterClass m_mainClass;
    public MonsterClass MainClass { get { return m_mainClass; } }
    [SerializeField] private int m_mainTypeEnergyCost;
    public int MainTypeEnergyCost { get { return m_mainTypeEnergyCost; } set { m_mainTypeEnergyCost = value; } }
    [SerializeField] private int m_otherTypeEnergyCost;
    public int OtherTypeEnergyCost { get { return m_otherTypeEnergyCost; } set { m_otherTypeEnergyCost = value; } }
    [SerializeField] private bool m_needTarget;
    public bool NeedTarget { get { return m_needTarget; } }
    #endregion
    public void UseSelf(MonsterCard target, PlayerManager player)
    {
        if ((TurnManager.Instance.Authority != player.ThisAuthority) && !IsInstance)
        {
            Debug.Log("Can not use spell, not our turn yet");
            return;
        }
        if (!NeedTarget)
        {
            if (target != null)
            {
                Debug.Log("Target shouldn't be choose here");
            }
            m_data.Spell(this.gameObject);
            return;
        }
        if (NeedTarget)
        {
            if (target == null)
            {
                Debug.Log("Cannot find target monster");
            }
            m_data.Spell(target, this.gameObject);
        }
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
        m_data.OtherTypeEnergyCost = m_otherTypeEnergyCost;
        m_data.IsInstance = m_isInstance;
        m_data.NeedTarget = m_needTarget;

        m_data.FrontSprite = FrontSprite;
        m_data.BackSprite = BackSprite;
        m_data.Name = CardName;
        m_data.SetID(CardID);
    }
    void InitData()
    {
        m_mainClass = m_data.MainClass;
        m_mainType = m_data.MainType;
        m_mainTypeEnergyCost = m_data.MainTypeEnergyCost;
        m_otherTypeEnergyCost = m_data.OtherTypeEnergyCost;
        m_isInstance = m_data.IsInstance;
        m_needTarget = m_data.NeedTarget;

        CardID = m_data.CardID;
        FrontSprite = m_data.FrontSprite;
        BackSprite = m_data.BackSprite;
        CardName = m_data.Name;
    }
}
