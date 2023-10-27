using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildedDeckContainer", menuName = "Game-Jam-Shit/BuildedDeckContainer", order = 0)]
public class BuildedDeckContainer : ScriptableObject {
    //TODO: Refactor this container to list<card>
    public MonsterCard[] MonsterCards = new MonsterCard[3];
    public SpellCard[] SpellCards = new SpellCard[20];
    public Energy[] Energies = new Energy[10];
    public void AddMonster()
    {
        
    }
    public void AddSpell()
    {

    }
    public void AddEnergy()
    {

    }
}
