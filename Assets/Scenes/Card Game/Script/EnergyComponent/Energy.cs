using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private MonsterTrait m_energyType;
    public MonsterTrait Type { get { return m_energyType; } }
    [SerializeField] private bool m_used;
    public bool Used { get { return m_used; } }
    public void OnHover()
    {

    }
    public void OnSelect()
    {

    }
    public void UseThis()
    {
        if (m_used)
        {
            Debug.Log("This energy is used already");
            return;
        }
        m_used = true;
    }
    public void Restore()
    {
        m_used = false;
    }
}
