using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager enemyManager;
    [SerializeField] private GameObject m_Environment;
    [SerializeField] private PlayerAuthority m_thisAuthority;
    [SerializeField] private BuildedDeckContainer m_playerCollection;
    public PlayerAuthority ThisAuthority {get {return m_thisAuthority;}}
    private List<MonsterCard> m_monsterCardsHand = new List<MonsterCard>();
    private MonsterCard m_activeMonster;
    [SerializeField] private int m_maxMonsterCardInHand;
    public int MaxMonsterCardInHand {get {return m_maxMonsterCardInHand;}}
    private List<SpellCard> m_spellHand = new List<SpellCard>();
    [SerializeField] private int m_maxSpellCardInHand;
    public int MaxSpellCardInHand {get {return m_maxSpellCardInHand;}}
    private List<Energy> m_energyHand = new List<Energy>();
    [SerializeField] private int m_maxEnergyCardInHand;
    public int MaxEnergyCardInHand {get {return m_maxEnergyCardInHand;}}
    private PlayerSpellDeck m_spellDeck;
    private PlayerEnergyDeck m_energyDeck;
    private PlayerMonsterDeck m_monsterDeck;
    #region action
    private UnityAction<PlayerAuthority> OnTurnChangeAction;
    private UnityAction<PlayerAuthority> OnPhaseChangeAction;
    #endregion

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
        m_monsterDeck = GetComponentInChildren<PlayerMonsterDeck>();

    }
    // Start is called before the first frame update
    void Start()
    {
        m_energyDeck.LoadFromCollection(m_playerCollection.Energies);
        m_spellDeck.LoadFromCollection(m_playerCollection.SpellCards);
        m_monsterDeck.LoadFromCollection(m_playerCollection.MonsterCards);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPlayerMonster()
    {
        Debug.Log("Load monster " + this.name);
        for (int iterator = 0; iterator < m_maxMonsterCardInHand; iterator++)
        {
            m_monsterCardsHand.Add(m_monsterDeck.LoadMonster(iterator));
            //TODO: Adject spawn card position
            GameObject.Instantiate(m_monsterCardsHand[iterator], this.gameObject.transform);
        }
        m_activeMonster = m_monsterCardsHand[0];

    }
    public void DrawCard()
    {
        if (m_spellHand.Count >= m_maxSpellCardInHand)
        {
            Debug.Log("Max Spell in hand reach");
            return;
        }
        m_spellHand.Add(m_spellDeck.DrawCard());
    }
    public void DrawEnergy()
    {
        if (m_energyHand.Count >= MaxEnergyCardInHand)
        {
            Debug.Log("Max Energy in hand reach");
            return;
        }
        Energy drawnCard = m_energyDeck.DrawCard();
        Debug.Log(drawnCard);
        m_energyHand.Add(drawnCard);
    }
    /// <summary>
    /// Set PLayer Authority to player 1/ player 2
    /// </summary>
    /// <param name="GM"></param> <summary>
    /// Game Manager to set authority, shouldnt be call by others class other than a game manager
    /// </summary>
    /// <param name="GM"></param>
    public void SetAuthority(GameManager GM, PlayerAuthority givenAuthority)
    {
        if (GM == null)
        {
            Debug.Log("Should be call without a game manager");
            return;
        }
        m_thisAuthority = givenAuthority;
    }

}
