using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_DOT : CardAddon
{

    [Header("DOT Addon Attributes")]
    public int damage;
    public int duration;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.DOT, damage, duration);
    }

    public override void Use()
    {
        EffectManager.instance.AddEffect(myHolder, Effect.Type.DOT, damage, duration, myTarget);
    }

    public override void TriggerEffect(Character target)
    {
        target.currentHealth -= damage;
        FightManager.instance.SpawnDamageText(damage, true, target);
    }
}
