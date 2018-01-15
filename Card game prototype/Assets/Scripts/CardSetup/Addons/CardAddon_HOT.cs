using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_HOT : CardAddon
{

    [Header("HOT Addon Attributes")]
    public int healAmount;
    public int duration;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.HOT, healAmount, duration);
    }

    public override void Use()
    {
        EffectManager.instance.AddEffect(myHolder, Effect.Type.HOT, healAmount, duration, myTarget);
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
