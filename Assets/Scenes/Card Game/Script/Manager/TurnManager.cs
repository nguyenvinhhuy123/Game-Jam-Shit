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
    private int m_turnCount = 0;
    public int TurnCount {get {return m_turnCount;}}
    private PlayerAuthority m_authority;
    public PlayerAuthority Authority {get {return m_authority;}}
    private PlayerAuthority m_firstToMove;
    public PlayerAuthority FirstToMove {get {return m_authority;}}

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
    }
    /// <summary>
    /// add listener to end of turn event
    /// Invoke param PlayerAuthority return player after change turn
    /// </summary>
    /// <param name="action"></param> <summary>
    /// action to add
    /// </summary>
    /// <param name="action"></param>
    public void AddListener(UnityAction<PlayerAuthority> action)
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
    public void RemoveListener(UnityAction<PlayerAuthority> action)
    {
        OnEndOfTurn.RemoveListener(action);
    }
}
