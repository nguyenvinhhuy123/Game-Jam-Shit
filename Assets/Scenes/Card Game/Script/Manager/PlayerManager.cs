using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager enemyManager;
    [SerializeField] private GameObject m_Environment;
    [SerializeField] private PlayerAuthority m_thisAuthority;
    
    private MonsterCard[] m_monsterCards = new MonsterCard[3];
    private SpellCardSOData[] m_spellDeck = new SpellCardSOData[20];
    private List<SpellCard> m_spellHand;
    private List<Energy> m_energies;
    //TODO: 
    void OnTurnChange()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
