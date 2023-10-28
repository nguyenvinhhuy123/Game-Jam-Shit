using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyDeck : MonoBehaviour
{
    public int MaxCardInDeck = 10;
    [SerializeField] private List<Energy> m_energyDeck;

    public void LoadFromCollection(Energy[] deckBuilded)
    {
        foreach (var energy in deckBuilded)
        {
            if (m_energyDeck.Count >= MaxCardInDeck)
            {
                Debug.Log("Deck is full");
                return;
            }
            m_energyDeck.Add(energy);
        }

    }
    public Energy DrawCard()
    {
        if (m_energyDeck.Count <= 0)
        {
            Debug.Log("No more card in deck");
            return null;
        }
        Energy EnergyToDraw;
        EnergyToDraw = m_energyDeck[Random.Range(0, m_energyDeck.Count)];
        m_energyDeck.Remove(EnergyToDraw);
        Debug.Log(EnergyToDraw);
        return EnergyToDraw;
    }
    public Energy DrawSpecificTraitEnergy(MonsterTrait trait)
    {
        if (m_energyDeck.Count <= 0)
        {
            Debug.Log("No more card in deck");
            return null;
        }
        Energy energyToDraw = null;
        foreach (var energy in m_energyDeck)
        {
            if (energy.Trait == trait)
            {
                energyToDraw = energy;
                break;
            }
        }
        if (energyToDraw != null)
        {
            m_energyDeck.Remove(energyToDraw);
        }
        else
        {
            Debug.Log("No more Energy Card of the trait");
            return null;
        }
        return energyToDraw;
    }
}
