using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Damage Increase")]
public class Card_DamageIncrease : Card
{

    [Header("Damage Increase Card Attributes")]
    public int damage;
    //public int uses;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        //myHolder.CreateAttribute(0, damage, 1);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        EffectManager.instance.AddEffect(myHolder, Effect.Type.DamageIncrease, damage);
    }
}
