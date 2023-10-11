using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Beast,
    Aquatic,
    Reptide,
    Bird,
    Bug,
    Plant

}
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
}
