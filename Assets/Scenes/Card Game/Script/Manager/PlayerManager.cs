using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager enemyManager;
    [SerializeField] private GameObject m_Environment;
    [SerializeField] private PlayerAuthority m_thisAuthority;
    public PlayerAuthority ThisAuthority {get {return m_thisAuthority;}}
    private MonsterCard[] m_monsterCardsHand = new MonsterCard[3];
    private MonsterCard m_activeMonster;
    private SpellCard[] m_spellHand = new SpellCard[10];
    private Energy[] m_energyHand = new Energy[10];
    private PlayerSpellDeck m_spellDeck;
    private PlayerEnergyDeck m_energyDeck;
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
