using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Spell Power")]
public class Card_DamageIncrease : Card
{

    [Header("Spell Power Card Attributes")]
    public int spellPower;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(CardAttribute.Type.DamageIncrease, spellPower);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        EffectManager.instance.AddEffect(myHolder, Effect.Type.SpellPower, spellPower, 0);
    }
}
