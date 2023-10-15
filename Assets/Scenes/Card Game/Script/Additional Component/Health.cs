using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_initHealthValue;
    public int HealthValue {get {return m_initHealthValue;} set {m_initHealthValue = value;}}
    [SerializeField] private int m_currentHealth;
    public int CurrentHealthValue {get {return m_currentHealth;} set{m_currentHealth -= value;}}

    void Awake()
    {
        
    }
    void Start()
    {
        InittHealth();
    }
    public void DamageSelf(int damage)
    {
        m_currentHealth -= damage;
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            KillSelf();
        }
    }
    private void KillSelf()
    {
        //TODO: disable card until round end
    }
    private void InittHealth()
    {
        m_currentHealth = m_initHealthValue;
    }
}
