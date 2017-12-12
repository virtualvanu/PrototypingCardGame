using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{

    [Header("General Variables")]
    public string cardName;

    public int cost;

    public int level;

    public virtual void Use()
    {

    }
}
