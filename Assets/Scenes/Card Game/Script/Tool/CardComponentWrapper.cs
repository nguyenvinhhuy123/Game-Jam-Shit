using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class CardComponentWrapper
{
    public SpriteRenderer m_spriteRenderer;
    public Collider2D m_collider2D;
    public Health m_health;
    public Attack m_attack;
    public AxieFigure m_axie;

    //TODO: Add component here
    public void InitComponent(GameObject GO)
    {
        m_spriteRenderer = GO.GetComponent<SpriteRenderer>();
        m_collider2D = GO.GetComponent<Collider2D>();
        m_health = GO.GetComponent<Health>();
        m_attack = GO.GetComponent<Attack>();
        m_axie = GO.GetComponentInChildren<AxieFigure>();
    }
}
