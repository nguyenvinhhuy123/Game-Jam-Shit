using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerAuthority
{
    PLAYER_1,
    PLAYER_2
}
public enum Phase
{
    PREPARATION_PHASE,
    PRE_COMBAT_PHASE,
    COMBAT_PHASE,
    POST_COMBAT_PHASE,
    END_PHASE
}

public class TurnManager : PersistenceSingleton<TurnManager>
{
    private UnityEvent<PlayerAuthority> OnEndOfTurn;
    private UnityEvent<Phase> OnEndOfPhase;
    private int m_turnCount = 0;
    public int TurnCount {get {return m_turnCount;}}
    private PlayerAuthority m_authority;
    public PlayerAuthority Authority {get {return m_authority;}}
    private PlayerAuthority m_firstToMove;
    public PlayerAuthority FirstToMove {get {return m_authority;}}
    private Phase m_currentPhase;
    public Phase CurrentPhase {get {return m_currentPhase;}}
    
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        OnEndOfTurn = new UnityEvent<PlayerAuthority>();
    }
    void Start()
    {
        m_turnCount = 0;
    }
    public void RequestEndOfPhase(PlayerAuthority requester)
    {
        if (requester != m_authority)
        {
            Debug.Log("Not " + requester + " turn, cannot request end of phase");
            return;
        }
        if (m_currentPhase == Phase.END_PHASE)
        {
            RequestEndOfTurn(requester);
            return;
        }
        m_currentPhase ++;
        
    }
    public void RequestEndOfTurn(PlayerAuthority requester)
    {
        if (requester != m_authority)
        {
            Debug.Log("Not " + requester + " turn, cannot request end of turn");
            return;
        }
        //?Should 1 turn count as 1 player play card or 2 player play card
        //*Option 1: player 1 authority -> Player 1 request end of turn -> turn++ -> player 2 authority -> player 2 request EOT -> turn++ -> ...*/
        //*Option 2: player 1 authority -> player 1 request EOT -> player 2 authority ->  player 2 request EOT -> turn ++ -> ... */
        //! Already Implement Option 1 here:
        //! Need Multiplayer Code for this
        m_turnCount++;
        if (requester == PlayerAuthority.PLAYER_1)
        {
            m_authority = PlayerAuthority.PLAYER_2;
        }
        else
        {
            m_authority = PlayerAuthority.PLAYER_1;
        }
        m_currentPhase = Phase.PREPARATION_PHASE;
        OnEndOfTurn.Invoke(m_authority);
    }
    /// <summary>
    /// Request register first player to move 
    /// </summary>
    /// <param name="diceRollWinner"></param> <summary>
    /// player who have higher roll
    /// </summary>
    /// <param name="diceRollWinner"></param>
    public void RequestFirstToMove(PlayerAuthority diceRollWinner)
    {
        m_firstToMove = diceRollWinner;
        m_turnCount ++;
        m_authority = m_firstToMove;
        m_currentPhase = Phase.PREPARATION_PHASE;
    }
    /// <summary>
    /// add listener to end of turn event
    /// Invoke param PlayerAuthority return player after change turn
    /// </summary>
    /// <param name="action"></param> <summary>
    /// action to add
    /// </summary>
    /// <param name="action"></param>
    public void AddEndOfTurnListener(UnityAction<PlayerAuthority> action)
    {
        OnEndOfTurn.AddListener(action);
    }

    /// <summary>
    /// add listener to end of turn event
    /// Invoke param PlayerAuthority return player after change turn
    /// </summary>
    /// <param name="action"></param> <summary>
    /// action to remove
    /// </summary>
    /// <param name="action"></param>
    public void RemoveEndOfTurnListener(UnityAction<PlayerAuthority> action)
    {
        OnEndOfTurn.RemoveListener(action);
    }
    /// <summary>
    /// Add listener to end of phase event
    /// EndOfPhaseEvent will return the current phase after change phase
    /// </summary>
    /// <param name="action"></param> <summary>
    /// action to add
    /// </summary>
    /// <param name="action"></param>
    public void AddEndOfPhaseListener(UnityAction<Phase> action)
    {
        OnEndOfPhase.AddListener(action);
    }
    /// <summary>
    /// Remove listener to end of phase event
    /// EndOfPhaseEvent will return the current phase after change phase
    /// </summary>
    /// <param name="action"></param> <summary>
    /// action to remove
    /// </summary>
    /// <param name="action"></param>
    public void RemoveEndOfTurnListener(UnityAction<Phase> action)
    {
        OnEndOfPhase.RemoveListener(action);
    }
    
    
}
