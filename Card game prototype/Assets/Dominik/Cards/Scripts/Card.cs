using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : ScriptableObject
{

    public enum Target
    {
        Ally,
        Enemy,
        Both
    }
    [Header("General Variables")]
    public Target target;

    public string cardName;

    public int manaCost;

    public int level;

    public Sprite icon;

    public GameObject useEffect;

    public virtual void Setup(CardHolder myHolder)
    {

    }

    public virtual void Use(CardHolder myHolder)
    {
        Debug.Log("Used the card: " + cardName);
    }
}
