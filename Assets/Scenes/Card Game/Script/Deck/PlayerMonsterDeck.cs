using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterDeck : MonoBehaviour
{
    public int MaxCardInDeck = 3; 
    [SerializeField] private List<MonsterCard> m_monsterDeck;

    public void LoadFromCollection(MonsterCard[] deckBuilded)
    {
        foreach (var energy in deckBuilded)
        {
            if (m_monsterDeck.Count >= MaxCardInDeck)
            {
                Debug.Log("Deck is full");
                return;
            }
            m_monsterDeck.Add(energy);
        }
    }
    public MonsterCard LoadMonster(int monsterIndex)
    {
        if (monsterIndex <  0 || monsterIndex >= MaxCardInDeck)
        {
            Debug.Log("Invalid Monster Index");
            return null;
        }
        return m_monsterDeck[monsterIndex];
    }
}
