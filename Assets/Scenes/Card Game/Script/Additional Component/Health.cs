using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_initHealthValue;
    public int InitHealthValue {get {return m_initHealthValue;}}
    [SerializeField] private int m_currentHealth;
    public int CurrentHealthValue {get {return m_currentHealth;}}
    [SerializeField] private int m_shieldValue;
    public int Shield {get {return m_shieldValue;}}
    [SerializeField] private int m_shieldDuration; //*Countdown by turn*/
    public int ShieldDuration {get {return m_shieldDuration;}}
    [SerializeField] private bool m_unitInactive;
    public bool UnitInactive {get {return m_unitInactive;}}
    
    private UnityAction<PlayerAuthority> OnTurnChangeAction;
    public UnityEvent OnKillSelfEvent;
    public UnityEvent<int, bool> OnHit;
    //* This event should return int: total damage receive; bool: is shielded */
    #region Callback
    void OnEnable()
    {
        OnTurnChangeAction += OnTurnChange;
    }
    void OnDisable()
    {
        OnTurnChangeAction -= OnTurnChange;
    }
    void Awake()
    {
        OnKillSelfEvent = new UnityEvent();
    }
    void Start()
    {
        TurnManager.Instance.AddEndOfTurnListener(OnTurnChangeAction);
    }
    void OnTurnChange(PlayerAuthority authority)
    {
        m_shieldDuration -= 1;
        if (m_shieldDuration <= 0)
        {
            m_shieldValue = 0;
        }
    }

    #endregion

    #region Method
    public void DamageSelf(int damage)
    {
        if (m_currentHealth <= 0)
        {
            Assert.AreEqual(true, m_unitInactive);
            Debug.Log(this.name + "is inactive due to dead");
            return;
        }
        if (m_shieldValue > 0)
        {
            m_shieldValue -= damage;
            if (m_shieldValue <= 0)
            {
                int damageToCastOnHealth = - m_shieldValue;
                m_currentHealth -= damageToCastOnHealth;
                m_shieldValue = 0;
                m_shieldDuration =0;
            }
        }
        else 
        {
            m_currentHealth -= damage;
        }
        
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            KillSelf();
        }
    }
    public void ApplyDOTSelf(int DOTDamage, int Duration)
    {
        //obsolete, no need this
    }
    private void KillSelf()
    {
        //TODO: disable card until round end
        m_unitInactive = true;
        Debug.Log(this.name + " is killed");
        OnKillSelfEvent.Invoke();
    }
    public void HealthSelf(int healAmount)
    {
        if (m_currentHealth == 0)
        {
            Assert.AreEqual(true, m_unitInactive);
            return;
        }
        m_currentHealth += healAmount;
        if (m_currentHealth >= m_initHealthValue)
        {
            m_currentHealth = m_initHealthValue;
        }
    }
    public void InitHealth(int health)
    {
        m_initHealthValue = health;
        m_currentHealth = m_initHealthValue;
    }
    public void AddOnKillSelfListener(UnityAction action)
    {
        OnKillSelfEvent.AddListener(action);
    }
    public void RemoveOnKillSelfListener(UnityAction action)
    {
        OnKillSelfEvent.RemoveListener(action);
    }
    public void ShieldSelf(int shieldAmount, int duration)
    {
        m_shieldValue = shieldAmount;
        m_shieldDuration = duration;
    }
    public void AddOnHitListener(UnityAction<int, bool> action)
    {
        OnHit.AddListener(action);
    }
    public void RemoveOnHitListener(UnityAction<int, bool>  action)
    {
        OnHit.RemoveListener(action);
    }

    #endregion
}
