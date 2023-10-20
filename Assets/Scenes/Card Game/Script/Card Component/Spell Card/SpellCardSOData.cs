using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game-Jam-Shit/SpellSO")]
public abstract class SpellCardSOData : CardSOData
{
    public int SpellCost;
    public MonsterSkill MainType;
    public MonsterCard MainClass;
    public int MainTypeEnergyCost;
    public int OtherTypeEnergyCost;
    public void CheckUsable(PlayerManager player)
    {

    }
    public virtual void Spell(MonsterCard target, GameObject player){}
    public virtual void Spell(GameObject player){}
    public virtual void RequestEndCardEffect(SpellCard caller)
    {
        
    }
}
