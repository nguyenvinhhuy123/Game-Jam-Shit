using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private MonsterType m_energyType;
    public MonsterType Type {get {return m_energyType;}}
    [SerializeField] private bool m_used;
    [SerializeField] private bool m_selected;
    
    public bool Used {get {return m_used;}}
    public bool Selected {get {return m_selected;}}
    
    public void OnSelect()
    {
        if (m_used)
        {
            Debug.Log("This energy is used already");
            return;
        }
        m_selected = true;
    }
    public void UseThis()
    {
        if (!m_selected)
        {
            Debug.Log("Can't use unselected energy");
            return;
        }
        m_used = true;
        Debug.Log("Energy used");
    }
    public void Refund()
    {
        m_used = false;
    }
}
