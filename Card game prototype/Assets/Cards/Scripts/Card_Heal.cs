using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Heal")]
public class Card_Heal : Card
{

    [Header("Heal Card Attributes")]
    public int healAmount;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(1, healAmount);
    }

    public override void Use()
    {
        base.Use();

        // heal yourself
        // maybe add a heal over time
        Debug.Log("Heal card healed " + healAmount + " health");

    }
}
