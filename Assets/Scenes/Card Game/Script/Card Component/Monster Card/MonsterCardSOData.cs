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
[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSO")]
public class MonsterCardSOData : CardSOData
{
    public int Health;
    public int Attack;
    public MonsterType Type;
    public int NormalAttackDamage;
    public int SkillDamage;
}
