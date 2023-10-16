using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Health),typeof(Attack))]
public class MonsterCard : Card
{
    [SerializeField] private MonsterCardSOData m_data;
    public CardComponentWrapper m_component;
    [SerializeField] private int m_attack;
    public int Attack {get {return m_attack;} set {m_attack = value;}}
    [SerializeField] private int m_health;
    public int Health {get {return m_health;} set {m_health = value;}}
    [SerializeField] private MonsterType m_type;
    public MonsterType Type {get {return m_type;} private set {m_type = value;}}
    [SerializeField] private MonsterNormalAttack m_normalAttack;
    public MonsterNormalAttack NormalAttack {get {return m_normalAttack;} set {m_normalAttack = value;}}
    [SerializeField] private MonsterSkill m_skill;
    public MonsterSkill Skill {get {return m_skill;} set {m_skill = value;}}
    [SerializeField] private int m_normalAttackDamage;
    public int NormalAttackDamage {get {return m_normalAttackDamage;} set {m_normalAttackDamage = value;}}
    [SerializeField] private int m_skillDamage;
    public int SkillDamage {get {return m_skillDamage;} set {m_skillDamage = value;}}


    //! Should we use a formula here??
    //* Something like NADamage = attack*multiplier + debuff */
    //*SkillDmg = Attack * Skill multiplier + debuff */
    //!Or Use a complete different scale??
    //*NADamage = NABaseDamage + debuff */
    //*SkillDmg = SkillBaseDmg + debuff */

    //Plus 2 Attack for card
    //Plus 2 NA dmg
    //* */
    void InitData()
    {
        #region set up parameter
            m_type = m_data.Type;
            m_attack = m_data.Attack;
            m_health = m_data.Health;
            m_normalAttackDamage = m_data.NormalAttackDamage;
            m_skillDamage = m_data.SkillDamage;
            FrontSprite = m_data.FrontSprite;
            BackSprite = m_data.BackSprite;
            CardName = m_data.Name; 
        #endregion


        #region set up sprite ui
            //! Suject to change:
            Debug.Log(m_component.m_spriteRenderer);
            //*This is now just basic sprite set up*/
            //m_component.m_spriteRenderer.sprite = FrontSprite;
        #endregion
        
    }
    void Awake()
    {
        m_component = new CardComponentWrapper();
        m_component.InitComponent(this.gameObject);
        InitData();
    }
    void Start()
    {
        InitData();
    }
    void OnValidate()
    {
        InitData();
    }
}
