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

        myHolder.CreateAttribute(CardAttribute.Type.Damage, damage);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character myTarget = DetermineTarget(myHolder);

        int totalDamage = damage;
        totalDamage += EffectManager.instance.CheckForPassiveEffect(Effect.Type.SpellPower, GetOtherTarget(myTarget));

        myTarget.currentHealth -= totalDamage;
        FightManager.instance.SpawnDamageText(totalDamage, true, myTarget);

        EffectManager.instance.TriggerEffects(true);
    }
}
