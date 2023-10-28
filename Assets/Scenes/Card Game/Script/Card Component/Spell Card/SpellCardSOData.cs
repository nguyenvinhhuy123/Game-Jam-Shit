using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game-Jam-Shit/SpellSO")]
public abstract class SpellCardSOData : CardSOData
{
    public MonsterTrait MainType;
    public MonsterClass MainClass;
    public int MainTypeEnergyCost;
    public int OtherTypeEnergyCost;
    public bool IsInstance;
    public bool NeedTarget;
    public void CheckUsable(PlayerManager player)
    {

    }
    public virtual void Spell(MonsterCard target, GameObject caller) { }
    public virtual void Spell(GameObject player) { }
    public virtual void RequestEndCardEffect(SpellCard caller)
    {

    }
}
