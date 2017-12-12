using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Heal")]
public class Card_Heal : Card
{

    [Header("Heal Card Attributes")]
    public float healAmount;

    public override void Use()
    {
        // heal yourself
        // maybe add a heal over time
    }
}
