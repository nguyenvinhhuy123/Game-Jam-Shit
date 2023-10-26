using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSkill")]
public abstract class MonsterSkill : ScriptableObject
{
    public string SkillName;
    public MonsterTrait MainTypeEnergy;
    public int SameTypeEnergyCost;
    public int OtherTypeEnergyCost;
    public string SkillDescription;
    public void CheckUsable(PlayerAuthority player)
    {

    }
    public virtual void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {

    }
    //TODO: Add player param
    //*Player param to adjust player energy according to cost*/
}

