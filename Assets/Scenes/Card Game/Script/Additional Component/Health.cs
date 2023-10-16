using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_initHealthValue;
    public int HealthValue {get {return m_initHealthValue;} set {m_initHealthValue = value;}}
    [SerializeField] private int m_currentHealth;
    public int CurrentHealthValue {get {return m_currentHealth;} set{m_currentHealth -= value;}}
    [SerializeField] private int m_shieldValue;
    public int Shield {get {return m_shieldValue;} set {m_shieldValue = value;}}
    [SerializeField] private int m_shieldDuration; //*Countdown by turn*/
    public int ShieldDuration {get {return m_shieldDuration;} set {m_shieldDuration = value;}}
    [SerializeField] private bool m_unitInactive;
    public bool UnitInactive {get {return m_unitInactive;}}
    public UnityEvent OnKillSelfEvent;
    void Awake()
    {
        OnKillSelfEvent = new UnityEvent();
    }
    void Start()
    {
        InitHealth();
    }
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
    private void OnTurnChange()
    {
        m_shieldDuration -= 1;
        if (m_shieldDuration < 0)
        {
            m_shieldValue = 0;
        }
    }
    private void InitHealth()
    {
        m_currentHealth = m_initHealthValue;
    }
    public void AddListener(UnityAction action)
    {
        OnKillSelfEvent.AddListener(action);
    }
    public void RemoveListener(UnityAction action)
    {
        OnKillSelfEvent.RemoveListener(action);
    }
}
