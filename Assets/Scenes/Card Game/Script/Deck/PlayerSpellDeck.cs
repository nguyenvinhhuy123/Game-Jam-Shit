using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpellDeck : MonoBehaviour
{
    public int MaxCardInDeck = 20; 
    [SerializeField] private List<SpellCard> m_spellDeck;
    
    public void LoadFromCollection(SpellCard[] deckBuilded)
    {
        foreach (var spellCard in deckBuilded)
        {
            if (m_spellDeck.Count >= MaxCardInDeck)
            {
                Debug.Log("Deck is full");
                return;
            }
            m_spellDeck.Add(spellCard);
        }
        
    }
    public SpellCard DrawCard()
    {
        if (m_spellDeck.Count <= 0)
        {
            Debug.Log("No more card in deck");
            return null;
        }
        SpellCard spellToDraw;
        spellToDraw = m_spellDeck[Random.Range(0, m_spellDeck.Count)];
        m_spellDeck.Remove(spellToDraw);
        return spellToDraw;
    }
}
