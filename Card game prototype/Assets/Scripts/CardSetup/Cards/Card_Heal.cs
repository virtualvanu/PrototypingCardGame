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

        myHolder.CreateAttribute(1, healAmount, 1);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character myTarget = DetermineTarget(myHolder);

        if (myTarget.currentHealth > (myTarget.maxHealth - healAmount))
        {
            myTarget.currentHealth = myTarget.maxHealth;
        }
        else
        {
            myTarget.currentHealth += healAmount;
        }

        FightManager.instance.SpawnDamageText(healAmount, false, DetermineDamageTextTarget(myHolder));
    }
}
