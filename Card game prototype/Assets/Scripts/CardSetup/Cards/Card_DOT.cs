using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DOT")]
public class Card_DOT : Card
{

    [Header("DOT Card Attributes")]
    public int damage;
    public int duration;

    private int totalDamage;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(2, damage, duration);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character target = DetermineTarget(myHolder);

        totalDamage = damage;
        totalDamage += EffectManager.instance.CheckForPassiveEffect(Effect.Type.DamageIncrease, target);

        EffectManager.instance.AddEffect(myHolder, Effect.Type.DOT, totalDamage, duration);
    }

    public override void TriggerEffect(Character target, Transform damageTextPos)
    {
        target.currentHealth -= totalDamage;
        FightManager.instance.SpawnDamageText(totalDamage, true, damageTextPos);
    }
}
