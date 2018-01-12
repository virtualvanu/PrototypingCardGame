using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Heal")]
public class Card_Heal : Card
{

    [Header("Heal Card Attributes")]
    public int healAmount;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(CardAttribute.Type.Heal, healAmount);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character myTarget = DetermineTarget(myHolder);

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
