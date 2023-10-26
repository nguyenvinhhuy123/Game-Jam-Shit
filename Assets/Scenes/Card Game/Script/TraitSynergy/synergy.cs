using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TraitSynergy : MonoBehaviour {
    public Dictionary<MonsterTrait, int> m_trait;
    foreach (MonsterTrait trait in MonsterCards){
        m_trait.Add(m_trait[trait]);
    }
    switch (m_trait){
        case m_trait[Bird] == 2:
            OnEndOfTurn.AddListener(Energy.Restore(Bird, 1));
            
        case m_trait[Bird] == 3:
            //TODO: NABuffHandler();
            
        case m_trait[Aquatic] == 2:
            Energy.AddEnergy(Aquatic, 1);
            
        case m_trait[Aquatic] == 3:
        //TODO: reduce energy cost 
            
        case m_trait[Reptile] == 2:
            foreach (MonsterTrait trait in MonsterCards){
                if (trait == "Reptile"){
                    MonsterCard[trait].Health += 3;
                }
            }
            
        case m_trait[Reptile] == 3:
            //todo: revive 
            
        case m_trait[Bug] == 2:
            if (MonsterCard.trait == "Bug" && MonsterSkill.OnUse(target, Bug, player)){
                target.ApplyDOTSelf(1, 1)
            }
            
        case m_trait[Bug] == 3:
            if (MonsterCard.trait == "Bug" && MonsterSkill.OnUse(target, Bug, player)){
                target.ApplyDOTSelf(1, 1)
            }
            
        case m_trait[Plant] == 2:
            if (MonsterCard.trait == "Plant" && MonsterSkill.OnUse(target, Plant, player)){
                target.HealthSelf(1)
            }
            
        case m_trait[Plant] == 3:
            OnEndOfTurn.AddListener(HealthSelf(1))
            
        case m_trait[Aquatic] >= 1 && m_trait[Bird] >= 1:
            Energy.AddEnergy(Bird, 1);
            //TODO: Aquatic Skill deal 1 less damage
        case m_trait[Aquatic] >= 1 && m_trait[Bug] >= 1:
            if (MonsterCard.traits == "Aquatic" && MonsterSkill.OnUse(target, Plant, player)) {
                DrawCard();
            }
            //TODO: Bug Skill deal 1 less damage
        }
        case m_trait[Aquatic] >= 1 && m_trait[Plant] >= 1:
            //TODO: on game start gain 1 more plant energy
            //TODO: Aquatic Skill deal 1 less damage
        case m_trait[Aquatic] >= 1 && m_trait[Reptile] >= 1:
    
}