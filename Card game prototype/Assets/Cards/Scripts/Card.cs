using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{

    public enum Side
    {
        Ally,
        Enemy
    }
    [Header("General Variables")]
    public Side side;

    //private Target target;

    public string cardName;

    public int manaCost;

    public int level;

    public GameObject useEffect;

    public virtual void Use()
    {
        Debug.Log("Used the card: " + cardName);

        switch (side)
        {
            case Side.Ally:

                //target = enemy;
                break;
            case Side.Enemy:

                //target = ally;
                break;
        }
    }
}
