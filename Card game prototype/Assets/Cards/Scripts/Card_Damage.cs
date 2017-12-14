using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Cards/Damage")]
public class Card_Damage : Card
{

    [Header("Damage Card Attributes")]
    public float damage;

    public override void Use()
    {
        // damage the enemy
        Debug.Log("Damage card did " + damage + " damage");
    }
}
