using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardSOData : ScriptableObject
{
    public int CardID {get; private set;}
    public string Name;
    public Sprite FrontSprite;
    public Sprite BackSprite;

    public void SetID(int id)
    {
        CardID = id;
    }
    
}
