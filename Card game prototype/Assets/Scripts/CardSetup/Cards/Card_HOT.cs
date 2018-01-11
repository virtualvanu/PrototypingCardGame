using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/HOT")]
public class Card_HOT : Card
{

    [Header("HOT Card Attributes")]
    public int healAmount;
    public int duration;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(3, healAmount, duration);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character myTarget = DetermineTarget(myHolder);

        if (myTarget.currentHealth > (myTarget.maxHealth - healAmount))
        {
            Debug.Log("HOT card healed " + (myTarget.maxHealth - myTarget.currentHealth) + " health");
            myTarget.currentHealth = myTarget.maxHealth;
        }
        else
        {
            Debug.Log("HOT card healed " + healAmount + " health");
            myTarget.currentHealth += healAmount;
        }

        FightManager.instance.SpawnDamageText(healAmount, false, DetermineDamageTextTarget(myHolder));
        EffectManager.instance.AddEffect(myHolder, healAmount, duration);
    }

    public override void TriggerEffect(Character target, Transform damageTextPos)
    {
        if (target.currentHealth > (target.maxHealth - healAmount))
        {
            Debug.Log("HOT card healed " + (target.maxHealth - target.currentHealth) + " health");
            target.currentHealth = target.maxHealth;
        }
        else
        {
            Debug.Log("HOT card healed " + healAmount + " health");
            target.currentHealth += healAmount;
        }

        FightManager.instance.SpawnDamageText(healAmount, false, damageTextPos);
    }
}
