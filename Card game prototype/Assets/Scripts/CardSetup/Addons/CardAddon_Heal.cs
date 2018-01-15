using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_Heal : CardAddon
{

    [Header("Damage Addon Attributes")]
    public int healAmount;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.Heal, healAmount);
    }

    public override void Use()
    {
        int totalHeal = healAmount;
        totalHeal += EffectManager.instance.CheckForPassiveEffect(Effect.Type.SpellPower, myTarget);

        if (myTarget.currentHealth > (myTarget.maxHealth - totalHeal))
        {
            myTarget.currentHealth = myTarget.maxHealth;
        }
        else
        {
            myTarget.currentHealth += totalHeal;
        }

        FightManager.instance.SpawnDamageText(totalHeal, false, myTarget);

        EffectManager.instance.TriggerEffects(true);
    }
}
