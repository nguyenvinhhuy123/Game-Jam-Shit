using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard : Card
{
    [SerializeField] private int m_spellCost;
    public int SpellCost {get {return m_spellCost;} set {m_spellCost = value;}}
    [SerializeField] private SpellCardSOData m_data;
    
    public void UseSelf(MonsterCard target)
    {
        m_data.Spell(target, this.gameObject);
    }
    public void UseSelf()
    {
        m_data.Spell(this.gameObject);
    }
}
