using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DOT")]
public class Card_DOT : Card
{

    [Header("DOT Card Attributes")]
    public float dotDamage;
    public float duration;

    public override void Use()
    {
        // deal damage over time (deals the dotDamage like every round)
        Debug.Log("DOT card did " + dotDamage + " damage for " + duration + " rounds");

    }
}
