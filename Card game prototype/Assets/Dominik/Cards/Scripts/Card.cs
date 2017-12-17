using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : ScriptableObject
{

    public enum Target
    {
        Ally,
        Enemy
    }
    [Header("General Variables")]
    public Target target;

    //private TargetObject targetObject;

    public string cardName;

    public int manaCost;

    public int level;

    public Sprite icon;

    public GameObject useEffect;

    public virtual void Setup(CardHolder myHolder)
    {

    }

    public virtual void Use()
    {
        Debug.Log("Used the card: " + cardName);

        switch (target)
        {
            case Target.Ally:

                //target = enemy;
                break;
            case Target.Enemy:

                //target = ally;
                break;
        }
    }
}
