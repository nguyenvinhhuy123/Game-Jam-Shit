using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : Card
{
    [SerializeField] private MonsterSOData m_data;
    [SerializeField] private int m_attack;
    public int Attack {get {return m_attack;} set {m_attack = value;}}
    [SerializeField] private int m_health;
    public int Health {get {return m_health;} set {m_health = value;}}
    [SerializeField] private MonsterType m_type;
    public MonsterType Type {get {return m_type;} private set {m_type = value;}}
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
        
    }
    void Awake()
    {
        InitData();
    }
    private void KillSelf()
    {
        //TODO: disable card until round end
    }
    public void DamageSelf(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            KillSelf();
        }
    }
}
