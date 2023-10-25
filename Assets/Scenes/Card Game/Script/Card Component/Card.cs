using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public abstract class Card : MonoBehaviour
{
    [Header("Card Base Attribute")]
    [SerializeField] private string m_cardName;
    public string CardName {get {return m_cardName;} protected set {m_cardName = value;}}
    [SerializeField] private int m_cardID;
    public int CardID {get {return m_cardID;} set {m_cardID = value;}}

    #region Sprite
    [SerializeField] private Sprite m_frontSprite;
    public Sprite FrontSprite {get {return m_frontSprite;} protected set {m_frontSprite = value;}}

    [SerializeField] private Sprite m_backSprite;
    public Sprite BackSprite {get {return m_backSprite;} protected set {m_backSprite = value;}}
    
    #endregion

    public virtual void OnHover()
    {
        
    }
    public virtual void OnSelect()
    {

    }
}
