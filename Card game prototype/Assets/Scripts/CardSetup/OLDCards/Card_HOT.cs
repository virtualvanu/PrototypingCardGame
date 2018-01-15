using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OLDCards/HOT")]
public class Card_HOT : Card
{

    [Header("HOT Card Attributes")]
    public int healAmount;
    public int duration;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(CardAttribute.Type.HOT, healAmount, duration);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        //EffectManager.instance.AddEffect(myHolder, Effect.Type.HOT, healAmount, duration);
    }

    public override void TriggerEffect(Character target)
    {
        if (target.currentHealth > (target.maxHealth - healAmount))
        {
            target.currentHealth = target.maxHealth;
        }
        else
        {
            target.currentHealth += healAmount;
        }

        FightManager.instance.SpawnDamageText(healAmount, false, target);
    }
}
