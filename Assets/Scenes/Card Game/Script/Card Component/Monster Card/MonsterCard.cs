using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[ExecuteInEditMode]
[RequireComponent(typeof(Health),typeof(Attack))]
public class MonsterCard : Card
{
    #region Data
    public CardComponentWrapper m_component;
    [SerializeField] private MonsterCardSOData m_data;
    [SerializeField] private SkeletonDataAsset m_animationAsset;
    public SkeletonDataAsset AnimationAsset {get {return m_animationAsset;} set {m_animationAsset = value;}}
    #endregion

    #region Atttribute
    
    [SerializeField] private int m_health;
    public int Health {get {return m_health;} set {m_health = value;}}
    [SerializeField] private MonsterType m_type;
    public MonsterType Type {get {return m_type;} private set {m_type = value;}}
    [SerializeField] private MonsterNormalAttack m_normalAttack;
    public MonsterNormalAttack NormalAttack {get {return m_normalAttack;} set {m_normalAttack = value;}}
    [SerializeField] private MonsterSkill m_skill;
    public MonsterSkill Skill {get {return m_skill;} set {m_skill = value;}}
    [SerializeField] private int m_normalAttackDamage;


    //? Should we use a formula here , Or Use a complete different scale??
    //!Option 1:
    //*NADamage = attack*multiplier + debuff */
    //*SkillDmg = attack*Skill multiplier + debuff */
    //!Option 2:
    //*NADamage = NABaseDamage + debuff */
    //*SkillDmg = SkillBaseDmg + debuff */

    //Plus 2 Attack for card
    //Plus 2 NA dmg
    //* */


    public int NormalAttackDamage {get {return m_normalAttackDamage;} set {m_normalAttackDamage = value;}}
    [SerializeField] private int m_skillDamage;
    public int SkillDamage {get {return m_skillDamage;} set {m_skillDamage = value;}}
    
    #endregion
    void InitData()
    {
        #region set up attribute
            m_type = m_data.Type;
            m_health = m_data.Health;
            m_normalAttackDamage = m_data.NormalAttackDamage;
            m_skillDamage = m_data.SkillDamage;
            FrontSprite = m_data.FrontSprite;
            BackSprite = m_data.BackSprite;
            CardName = m_data.Name; 
            m_animationAsset = m_data.SkeletonAsset;
        #endregion
    }
    void OnEnable()
    {
        m_component = new CardComponentWrapper();
        m_component.InitComponent(this.gameObject);
    }
    void Awake()
    {
        m_component = new CardComponentWrapper();
        m_component.InitComponent(this.gameObject);
    }
    void Start()
    {
        m_component.m_axieAnimation.skeletonDataAsset = m_data.SkeletonAsset;
        InitData();
    }
    void OnValidate()
    {
        InitData();
    }
}
