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
        FightManager.instance.SpawnDamageText(damage, true, DetermineDamageTextTarget(myHolder));

        EffectManager.instance.AddEffect(myHolder, damage, duration);

        Debug.Log("DOT card did " + damage + " damage for " + duration + " rounds");
    }

    public override void TriggerEffect(Character target, Transform damageTextPos)
    {
        target.currentHealth -= damage;
        FightManager.instance.SpawnDamageText(damage, true, damageTextPos);

        Debug.Log("DOT card did " + damage + " damage as a DOT");
    }
}
