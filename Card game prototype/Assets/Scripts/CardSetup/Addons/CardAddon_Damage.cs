using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_Damage : CardAddon
{

    [Header("Damage Addon Attributes")]
    public int damage;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.Damage, damage);
    }

    public override void Use()
    {
        int totalDamage = damage;
        totalDamage += EffectManager.instance.CheckForPassiveEffect(Effect.Type.SpellPower, GetOtherTarget());

        myTarget.currentHealth -= totalDamage;
        FightManager.instance.SpawnDamageText(totalDamage, true, myTarget);

        EffectManager.instance.TriggerEffects(true);
    }
}
