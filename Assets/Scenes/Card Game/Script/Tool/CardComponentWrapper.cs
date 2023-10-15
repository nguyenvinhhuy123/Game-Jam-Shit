using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponentWrapper
{
    public SpriteRenderer m_spriteRenderer;
    public Collider2D m_collider2D;

    //TODO: Add component here
    public void InitComponent(GameObject GO)
    {
        m_spriteRenderer = GO.GetComponent<SpriteRenderer>();
        m_collider2D = GO.GetComponent<Collider2D>();
        
    }
}
