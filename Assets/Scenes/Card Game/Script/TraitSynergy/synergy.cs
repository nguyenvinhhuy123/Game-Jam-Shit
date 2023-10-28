using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using BuffSystem;
using Game;
using System;

public class TraitSynergy : MonoBehaviour
{
    public Dictionary<MonsterTrait, int> m_trait = new Dictionary<MonsterTrait, int>();
    public void countTraitSynergy(MonsterCard[] deckBuilded)
    {
        foreach (MonsterCard card in deckBuilded)
        {
            if (!m_trait.ContainsKey(card.Trait))
            {
                m_trait.Add(card.Trait, 1);
            }
            else
            {
                m_trait[card.Trait]++;
            }
        }
    }
    private PlayerManager m_cacheManager;
    private UnityAction<PlayerAuthority> OnTurnChangeAction;

    public void OnTurnChange(PlayerAuthority authority)
    {
        if (authority != m_cacheManager.ThisAuthority)
        {
            return;
        }
        else
        {
            m_cacheManager.DrawCard();
        }
    }
    public void checkPairTraitSynergy()
    {
        foreach (KeyValuePair<MonsterTrait, int> entry in m_trait)
        {
            switch (entry.Key)
            {
                // 2 Bird: Refund 1 Bird Energy when turn ends.
                // 3 Bird: Birds Normal Attack cost 1 more Bird energy, Bird Normal Atttack deal 2 more damage
                case MonsterTrait.Bird:
                    if (entry.Value == 2)
                    {
                        TurnManager.Instance.AddEndOfTurnListener(OnTurnChangeAction);
                    }
                    else if (entry.Value == 3)
                    {
                        //TODO:
                    }
                    break;

                // 2 Aquatic: +1 Aquatic Energy when game start (does not stack).
                // 3 Aquatic: All Aquatic monsters’ Skill costs 1 less Aquatic energy.
                case MonsterTrait.Aquatic:
                    if (entry.Value == 2)
                    {

                    }
                    else if (entry.Value == 3)
                    {
                        //TODD: 
                    }
                    break;

                // 2 Reptile: All Reptile monsters gain 3 additional max HP.
                // 3 Reptile: Once per game, revive the first Reptile monster that gets taken down back up 5 HP.  
                case MonsterTrait.Reptile:
                    if (entry.Value == 2)
                    {
                        //TODO
                    }
                    else if (entry.Value == 3)
                    {
                        //TODD: revive :trolldespair:
                    }
                    break;
                // 2 Bug: Every time a Bug uses a Skill to attack an opponent monster,
                // that monster will get poisoned (-1 HP per turn) for 1 turn.
                // 3 Bug: Bug's poison now last 1 additional turn
                case MonsterTrait.Bug:
                    if (entry.Value == 2)
                    {
                        //TODO
                    }
                    else if (entry.Value == 3)
                    {
                        //TODD: 
                    }
                    break;

                // 2 Plant: Every time a Plant monster uses a Skill, heals that monster for 1 HP.
                // 3 Plant: Heal the active Plant monster for 1 HP per turn.
                case MonsterTrait.Plant:
                    if (entry.Value == 2)
                    {
                        //TODO
                    }
                    else if (entry.Value == 3)
                    {
                        //TODD: 
                    }
                    break;
            }
        }
    }

    // If this trait synergy is available, create a gameObject contain this synergy behavior in scene.
    // This will work throughout the game scene until game end. 
    public void checkSingleTraitSynergy()
    {
        foreach (KeyValuePair<MonsterTrait, int> entry in m_trait)
        {
            if (entry.Key == MonsterTrait.Aquatic && m_trait.ContainsKey(MonsterTrait.Bird))
            {
                GameManager.Instance.gameObject.Instantiate("AquaticAndBird");
                // +1 Bird Energy per turn, Aquatic Skill damage deals 1 less damage.
                //Energy.AddEnergy(Bird, 1);

                //TODO: Aquatic Skill deal 1 less damage
            }
            else if (entry.Key == MonsterTrait.Aquatic && m_trait.ContainsKey(MonsterTrait.Bug))
            {
                // Draw a card every time Aquatic monster use a SKill, Bug monster Skill deals 1 less damage
                if (MonsterCard.trait == "Aquatic" && MonsterSkill.OnUse(target, Plant, player))
                {
                    //DrawCard();
                }
                //TODO: Bug Skill deal 1 less damage
            }
            else if (entry.Key == MonsterTrait.Aquatic && m_trait.ContainsKey(MonsterTrait.Plant))
            {
                // Gain 1 additional Plant Energy when game start, Aquatic Skill damage deals 1 less damage.
                //TODO: on game start gain 1 more plant energy
                //TODO: Aquatic Skill deal 1 less damage
            }
            else if (entry.Key == MonsterTrait.Aquatic && m_trait.ContainsKey(MonsterTrait.Reptile))
            {
                // Once A Turn Aquatic monster heal 1 Health , Reptile Skill costs 1 more Reptile Energy.
                if (MonsterCard.traits == "Reptile")
                {
                    //OnEndOfTurn.AddListener(HealthSelf(1));
                    //TODO: Reptile Skill cost 1 more Reptile energy
                }
            }
            else if (entry.Key == MonsterTrait.Bird && m_trait.ContainsKey(MonsterTrait.Bug))
            {
                // Once per turn Draw a card when the first Bird use a Normal attack, -2 max HP for Bug.
                if (MonsterCard.traits == "Bird" && MonsterNormalAttack.OnUse(target, Plant, player))
                {
                    OnEndOfTurn.addListener(DrawCard());
                }
                foreach ()
                {
                    MonsterCard.Health -= 2;
                }
            }
            else if (entry.Key == MonsterTrait.Bird && m_trait.ContainsKey(MonsterTrait.Plant))
            {
                //Gain 1 additional Plant Energy when game start, Bird Normal Attack needs 1 more other Energy to use.
                // TODO: on game start gain 1 more plant energy
                // TODO: Bird Normal Attack needs 1 more other Energy to use.
            }
            else if (entry.Key == MonsterTrait.Bird && m_trait.ContainsKey(MonsterTrait.Reptile))
            {
                // Reptile Skill cost 1 less other Energy, Bird -2 max HP
                // TODO: 
            }
            else if (entry.Key == MonsterTrait.Bug && m_trait.ContainsKey(MonsterTrait.Plant))
            {
                // Every time Bug uses a Skill Attack, heals 1 HP; Plant Skill damage deals 1 less damage.
                if (MonsterCard.traits == "Bug" && MonsterNormalAttack.OnUse(target, Plant, player))
                {
                    //OnEndOfTurn.addListener(HealthSelf(1));
                }
                // TODO: Plant Skill damage deals 1 less damage.
            }
            else if (entry.Key == MonsterTrait.Bug && m_trait.ContainsKey(MonsterTrait.Reptile))
            {
                // Bug monster Skill deal 1 more damage, Reptile Normal Attacks deal 1 less damage.
            }
            else if (entry.Key == MonsterTrait.Plant && m_trait.ContainsKey(MonsterTrait.Reptile))
            {
                // Heal Reptile 1 HP every time that Reptile monster uses a Skill, Plant monster loses 1 HP every turn.
                if (MonsterCard.traits == "Reptile" && MonsterNormalAttack.OnUse(target, Plant, player))
                {
                    //OnEndOfTurn.addListener(HealthSelf(1));
                }
                if (MonsterCard.traits == "Plant" && MonsterNormalAttack.OnUse(target, Plant, player))
                {
                    //OnEndOfTurn.addListener(ApplyDOTSelf(1, 0));
                }
            }

        }

    }
}
