using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private MonsterTrait m_energyTrait;
    public MonsterTrait Trait { get { return m_energyTrait; } }
    [SerializeField] private bool m_used;
    public bool Used { get { return m_used; } }
    private List<Energy> m_energyDeck;
    public void OnHover()
    {

    }
    public void OnSelect()
    {

    }
    public void UseThis()
    {
        if (m_used)
        {
            Debug.Log("This energy is used already");
            return;
        }
        m_used = true;
    }
    public void Restore()
    {
        m_used = false;
    }
    public DrawSpecificTraitEnergy(MonsterTrait trait)
    {
        if (m_energyDeck.Count <= 0)
        {
            Debug.Log("No more card in deck");
            return null;
        }
        Energy energyToDraw;
        if (m_energyDeck.Contains(trait))
        {
            energyToDraw = m_energyDeck[m_energyDeck.IndexOf(trait)];
            m_energyDeck.Remove(energyToDraw);
        }
        return energyToDraw;
    }
}
