using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyDeck : MonoBehaviour
{
    public int MaxCardInDeck = 10; 
    public List<Energy> m_energyDeck;
    
    public void LoadFromCollection(List<Energy> deckBuilded)
    {
        foreach (var energy in deckBuilded)
        {
            if (m_energyDeck.Count >=20)
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
        return EnergyToDraw;
    }
}
