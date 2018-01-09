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

        if (damageTarget.currentHealth > (damageTarget.maxHealth - healAmount))
        {
            Debug.Log("Heal card healed " + (damageTarget.maxHealth - damageTarget.currentHealth) + " health");
            damageTarget.currentHealth = damageTarget.maxHealth;
        }
        else
        {
            Debug.Log("Heal card healed " + healAmount + " health");
            damageTarget.currentHealth += healAmount;
        }

        FightManager.instance.SpawnDamageText(healAmount, false, damageTextTarget);
    }
}
