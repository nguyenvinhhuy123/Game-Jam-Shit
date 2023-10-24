using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "BuildedDeckContainer", menuName = "Game-Jam-Shit/BuildedDeckContainer", order = 0)]
public class BuildedDeckContainer : ScriptableObject {
    public MonsterCard[] MonsterCards = new MonsterCard[3];
    public SpellCard[] SpellCards = new SpellCard[20];
    public Energy[] Energies = new Energy[10];
}
