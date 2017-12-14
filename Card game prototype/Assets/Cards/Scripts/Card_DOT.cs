using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DOT")]
public class Card_DOT : Card
{

    [Header("DOT Card Attributes")]
    public int dotDamage;
    public int duration;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(2, dotDamage);
    }

    public override void Use()
    {
        base.Use();

        // deal damage over time (deals the dotDamage like every round)
        Debug.Log("DOT card did " + dotDamage + " damage for " + duration + " rounds");

    }
}
