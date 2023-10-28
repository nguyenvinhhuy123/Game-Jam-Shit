using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSkill")]
public abstract class MonsterSkill : ScriptableObject
{
    public string SkillName;
    public MonsterType MainTypeEnergy;
    public int SameTypeEnergyCost;
    public int OtherTypeEnergyCost;
    public string SkillDescription;
    public bool NeedTarget;
    public bool CheckUsable(PlayerManager player)
    {
        int same = 0;
        foreach (var energy in player.EnergyHand)
        {
            if (energy.Type == MainTypeEnergy) same++;
            if (same >= SameTypeEnergyCost) break;
        }
        if (same < SameTypeEnergyCost || player.EnergyHand.Count - same  < OtherTypeEnergyCost)
        {
            Debug.Log("Not enough energy");
            return false;
        }
        return true;
    }
    public virtual void OnUse(MonsterCard target, MonsterCard user, PlayerManager player)
    {
        //Attack:
        //User.m_component
        if(!CheckUsable(user)) return;
    }
    public virtual void OnUse(MonsterCard user, PlayerManager player)
    {
        
    }
    //TODO: Add player param
    //*Player param to adjust player energy according to cost*/
}

