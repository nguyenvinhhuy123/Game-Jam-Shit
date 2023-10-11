using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSkill")]
public abstract class MonsterSkill : ScriptableObject
{
    public string SkillName;
    public int EnergyCost;
    public abstract void OnUse(MonsterCard target);
    //TODO: Add player param
    //*Player param to adjust player energy according to cost*/
}

