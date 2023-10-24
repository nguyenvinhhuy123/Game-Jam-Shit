using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "CardDatabase", menuName = "Game-Jam-Shit/CardDatabase", order = 0)]
public class CardDatabase : ScriptableObject {
    public static int IDGenerator = 0;
    public int MonsterCardCounter {get; private set;}
    public int SpellCardCounter {get; private set;}
    public List<MonsterCardSOData> MonsterCardDatabase = new List<MonsterCardSOData>();
    public List<SpellCardSOData> SpellCardDatabase =  new List<SpellCardSOData>();
    int CreateUniqueID()
    {
        return IDGenerator++;
    }
    void OnValidate()
    {
        if (MonsterCardCounter < MonsterCardDatabase.Count)
        {
            MonsterCardSOData lastAppend = MonsterCardDatabase.Last();
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
            setUniqueIDMonster();
        }
        else if (SpellCardCounter < SpellCardDatabase.Count)
        {
            SpellCardSOData lastAppend = SpellCardDatabase.Last();
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
            setUniqueIDSpell();
        }
    }
    void setUniqueIDMonster()
    {
        MonsterCardDatabase.Last().SetID(CreateUniqueID());
        MonsterCardCounter++;
    }
    void setUniqueIDSpell()
    {
        SpellCardDatabase.Last().SetID(CreateUniqueID());
        SpellCardCounter++;
    }
    
}
