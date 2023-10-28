using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TraitSynergy : MonoBehaviour {
    public Dictionary<MonsterTrait, int> m_class;
    foreach (MonsterClass in MonsterCards){
        m_class.Add(m_class[class]);
    }
    switch (m_class){
        case m_class[Mouth] >= 2:
            foreach (MonsterClass class in MonsterCards){
                if (class  == "Mouth") {
                    //TODO: Normal Attack damage +1
                }
            }
            break;
        case m_class[Back] >= 2:
            foreach (MonsterClass class in MonsterCards){
                if (class == "Back") {
                    MonsterCard.Health += 3;
                }
            }
            break;
        case m_class[Horn] >= 2:
            foreach (MonsterClass class in MonsterCards){{
                if (class == "Horn") {
                    //TODO: Skill damage +2
                }
            }
            break;
        case m_class[Tail] >= 2:
            //TODO: Heal 1 
    }
}