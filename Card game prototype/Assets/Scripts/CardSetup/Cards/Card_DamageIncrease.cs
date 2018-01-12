using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Damage Increase")]
public class Card_DamageIncrease : Card
{

    [Header("Damage Increase Card Attributes")]
    public int damage;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(CardAttribute.Type.DamageIncrease, damage);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        EffectManager.instance.AddEffect(myHolder, Effect.Type.SpellPower, damage, 0);
    }
}
