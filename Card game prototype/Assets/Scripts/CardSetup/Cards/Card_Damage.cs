using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Cards/Damage")]
public class Card_Damage : Card
{

    [Header("Damage Card Attributes")]
    public int damage;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(0, damage, 1);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character target = DetermineTarget(myHolder);

        int totalDamage = damage;
        totalDamage += EffectManager.instance.CheckForPassiveEffect(Effect.Type.DamageIncrease, target);

        target.currentHealth -= totalDamage;
        FightManager.instance.SpawnDamageText(totalDamage, true, DetermineDamageTextTarget(myHolder));

        EffectManager.instance.TriggerPassiveEffects(target);
    }
}
