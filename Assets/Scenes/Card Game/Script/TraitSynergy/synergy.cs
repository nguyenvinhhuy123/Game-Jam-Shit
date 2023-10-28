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

        // 2 Bird: Refund 1 Bird Energy when turn ends.
        case m_trait[Bird] == 2:
            OnEndOfTurn.AddListener(Energy.Restore(Bird, 1));
            
        // 3 Bird: Birds Normal Attack cost 1 more Bird energy, Bird Normal Atttack deal 2 more damage
        case m_trait[Bird] == 3:
            //TODO: NABuffHandler();
            
        // 2 Aquatic: +1 Aquatic Energy per turn (does not stack).
        case m_trait[Aquatic] == 2:
            Energy.AddEnergy(Aquatic, 1);
            
        // 3 Aquatic: All Aquatic monsters’ Skill costs 1 less Aquatic energy.
        case m_trait[Aquatic] == 3:
        //TODO: reduce energy cost 
            
        // 2 Reptile: All Reptile monsters gain 3 additional max HP.
        case m_trait[Reptile] == 2:
            foreach (MonsterTrait trait in MonsterCards){
                if (trait == "Reptile"){
                    MonsterCard[trait].Health += 3;
                }
            }

        // 3 Reptile: Once per game, revive the first Reptile monster that gets taken down back up 5 HP.    
        case m_trait[Reptile] == 3:
            //todo: revive :trolldespair:
            
        // 2 Bug: Every time a Bug uses a Skill to attack an opponent monster,
        // that monster will get poisoned (-1 HP per turn) for 1 turn.
        case m_trait[Bug] == 2:
            if (MonsterCard.trait == "Bug" && MonsterSkill.OnUse(target, Bug, player)){
                target.ApplyDOTSelf(1, 1)
            }
            
        // 3 Bug: Bug's poison now last 1 additional turn
        case m_trait[Bug] == 3:
            if (MonsterCard.trait == "Bug" && MonsterSkill.OnUse(target, Bug, player)){
                target.ApplyDOTSelf(1, 1)
            }
            
        // 2 Plant: Every time a Plant monster uses a Skill, heals that monster for 1 HP.
        case m_trait[Plant] == 2:
            if (MonsterCard.trait == "Plant" && MonsterSkill.OnUse(target, Plant, player)){
                target.HealthSelf(1)
            }
            
        // 3 Plant: Heal the active Plant monster for 1 HP per turn.
        case m_trait[Plant] == 3:
            OnEndOfTurn.AddListener(HealthSelf(1))
            
        // +1 Bird Energy per turn, Aquatic Skill damage deals 1 less damage.
        case m_trait[Aquatic] >= 1 && m_trait[Bird] >= 1:
            Energy.AddEnergy(Bird, 1);
            //TODO: Aquatic Skill deal 1 less damage
        
        // Draw a card every time Aquatic monster use a SKill, Bug monster Skill deals 1 less damage
        case m_trait[Aquatic] >= 1 && m_trait[Bug] >= 1:
            if (MonsterCard.traits == "Aquatic" && MonsterSkill.OnUse(target, Plant, player)) {
                DrawCard();
            }
            //TODO: Bug Skill deal 1 less damage
        }

        // Gain 1 additional Plant Energy when game start, Aquatic Skill damage deals 1 less damage.
        case m_trait[Aquatic] >= 1 && m_trait[Plant] >= 1:
            //TODO: on game start gain 1 more plant energy
            //TODO: Aquatic Skill deal 1 less damage

        // Once A Turn Aquatic monster heal 1 Health , Reptile Skill costs 1 more Reptile Energy.
        case m_trait[Aquatic] >= 1 && m_trait[Reptile] >= 1:
            if (MonsterCard.traits == "Reptile"){
                OnEndOfTurn.AddListener(HealthSelf(1))
            }
            //TODO: Reptile Skill cost 1 more Reptile energy
        
        // Once per turn Draw a card when the first Bird use a Normal attack, -2 max HP for Bug.
        case m_trait[Bird] >= 1 && m_trait[Bug] >= 1:
            if (MonsterCard.traits == "Bird" && MonsterNormalAttack.OnUse(target, Plant, player)) {
                OnEndOfTurn.addListener(DrawCard());
            }
            foreach (Monster
            if (MonsterCard.traits == "Bug"){
                MonsterCard.Health -= 2
            }
        
        //Gain 1 additional Plant Energy when game start, Bird Normal Attack needs 1 more other Energy to use.
        case m_trait[Bird] >= 1 && m_trait[Plant] >1:
            // TODO: on game start gain 1 more plant energy
            // TODO: Bird Normal Attack needs 1 more other Energy to use.

        // Reptile Skill cost 1 less other Energy, Bird -2 max HP
        case m_trait[Bird] >= 1 && m_trait[Reptile]: 
            // TODO: Reptile skill cost 1 less other energy
            if (MonsterCard.traits == "Bug"){
                MonsterCard.Health -= 2
            }

        // Every time Bug uses a Skill Attack, heals 1 HP; Plant Skill damage deals 1 less damage.
        case m_trait[Bug] >= 1 && m_trait[Plant] >= 1:
            if (MonsterCard.traits == "Bug" && MonsterNormalAttack.OnUse(target, Plant, player)) {
                OnEndOfTurn.addListener(HealthSelf(1));
            }
            // TODO: Plant Skill damage deals 1 less damage.

        // Bug monster Skill deal 1 more damage, Reptile Normal Attacks deal 1 less damage.
        case m_trait[Bug] >= 1 && m_trait[Reptile] >= 1:
            // TODO: 
        
        // Heal Reptile 1 HP every time that Reptile monster uses a Skill, Plant monster loses 1 HP every turn.
        case m_trait[Plant] >= 1 && m_trait[Reptile] >= 1:
            if (MonsterCard.traits == "Reptile" && MonsterNormalAttack.OnUse(target, Plant, player)) {
                OnEndOfTurn.addListener(HealthSelf(1));
            }
            
            if (MonsterCard.traits == "Plant" && MonsterNormalAttack.OnUse(target, Plant, player)) {
                OnEndOfTurn.addListener(ApplyDOTSelf(1, 0));
            }
}