using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSOData")]
public class MonsterSOData : CardSOData
{
    public MonsterType Type;
    public int Attack;
    public int Health;
    public int AttackSpeed; //To check whose go first every turn??
    public MonsterSkill Skill;
}
