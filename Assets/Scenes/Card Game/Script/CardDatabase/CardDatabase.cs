using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "CardDatabase", menuName = "Game-Jam-Shit/CardDatabase", order = 0)]
public class CardDatabase : ScriptableObject {
    public static int IDGenerator = 0;
    public int MonsterCardCounter {get; private set;}
    public int SpellCardCounter {get; private set;}
    public List<MonsterCard> MonsterCardDatabase = new List<MonsterCard>();
    public List<SpellCard> SpellCardDatabase =  new List<SpellCard>();
    int CreateUniqueID()
    {
        return IDGenerator++;
    }
    void OnValidate()
    {
        if (
            MonsterCardDatabase.Count == 0
            && SpellCardDatabase.Count == 0
        )
        {
            //Reset database card ID;
            IDGenerator = 0;
            MonsterCardCounter = 0;
            SpellCardCounter = 0;
            return;
        }
        if (MonsterCardCounter > MonsterCardDatabase.Count)
        {
            MonsterCardCounter = MonsterCardDatabase.Count;
            return;
        }
        if (SpellCardCounter > SpellCardDatabase.Count)
        {
            SpellCardCounter = SpellCardDatabase.Count;
            return;
        }
        if (MonsterCardCounter < MonsterCardDatabase.Count)
        {
            MonsterCard lastAppend = MonsterCardDatabase.Last();
            
            if (lastAppend == null)
            {
                #if UNITY_EDITOR
                Debug.Log("last element is null, please add an element");
                #endif
                return;
            }

            for (int iterator = 0; iterator < MonsterCardDatabase.Count - 1; iterator++)
            {
                if (MonsterCardDatabase[iterator] == lastAppend)
                {
                    #if UNITY_EDITOR
                    Debug.Log("Same card detected in database, please assign new value");
                    #endif
                    return;
                }
            }
            SetUniqueIDMonster();
        }
        else if (SpellCardCounter < SpellCardDatabase.Count)
        {
            SpellCard lastAppend = SpellCardDatabase.Last();
            if (lastAppend == null)
            {
                #if UNITY_EDITOR
                Debug.Log("last element is null, please add an element");
                #endif
                return;
            }
            for (int iterator = 0; iterator < SpellCardDatabase.Count - 1; iterator++)
            {
                if (SpellCardDatabase[iterator] == lastAppend)
                {
                    #if UNITY_EDITOR
                    Debug.Log("Same card detected in database, please assign new value");
                    #endif
                    return;
                }
            }
            SetUniqueIDSpell();
        }
    }
    void SetUniqueIDMonster()
    {
        MonsterCardDatabase.Last().CardID = CreateUniqueID();
        MonsterCardCounter++;
    }
    void SetUniqueIDSpell()
    {
        SpellCardDatabase.Last().CardID = CreateUniqueID();
        SpellCardCounter++;
    }
    
}
