using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager enemyManager;
    [SerializeField] private GameObject m_Environment;
    [SerializeField] private PlayerAuthority m_thisAuthority;
    
    private MonsterCard[] m_monsterCardsHand = new MonsterCard[3];
    private SpellCard[] m_spellHand = new SpellCard[10];
    private Energy[] m_energyHand = new Energy[10];
    private PlayerSpellDeck m_spellDeck;
    private PlayerEnergyDeck m_energyDeck;
    private UnityAction<PlayerAuthority> OnTurnChangeAction;
    private UnityAction<PlayerAuthority> OnPhaseChangeAction;
    //TODO: 
    void OnEnable()
    {

    }
    void OnDisable()
    {
        
    }
    void OnTurnChange()
    {
        
    }
    void Awake()
    {
        m_spellDeck = GetComponentInChildren<PlayerSpellDeck>();
        m_energyDeck = GetComponentInChildren<PlayerEnergyDeck>();
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
