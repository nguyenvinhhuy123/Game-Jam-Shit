using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager enemyManager;
    [SerializeField] private GameObject m_Environment;
    [SerializeField] private PlayerAuthority m_thisAuthority;
    
    private MonsterCard[] m_monsterCardsHand = new MonsterCard[3];
    private SpellCard[] m_spellHand = new SpellCard[10];
    private List<SpellCard> m_spellDeck;
    private List<Energy> m_energyDeck;
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
    public void DrawCard()
    {

    }
    public void DrawEnergy()
    {
        
    }
}
