using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DOT")]
public class Card_DOT : Card
{

    [Header("DOT Card Attributes")]
    public int damage;
    public int duration;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(2, damage, duration);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        DetermineTarget(myHolder).currentHealth -= damage;

        Debug.Log("DOT card did " + damage + " damage for " + duration + " rounds");
    }
}
