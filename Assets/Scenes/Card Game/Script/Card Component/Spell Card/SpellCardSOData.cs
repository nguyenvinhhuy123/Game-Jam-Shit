using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game-Jam-Shit/SpellSO")]
public abstract class SpellCardSOData : ScriptableObject
{
    public int SpellCost;
    public virtual void Spell(MonsterCard target, GameObject caster){}
    public virtual void Spell(GameObject caster){}
}
