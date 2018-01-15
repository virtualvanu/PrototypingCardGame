using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_SpellPower : CardAddon
{

    [Header("SpellPower Addon Attributes")]
    public int spellPower;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.SpellPower, spellPower);
    }

    public override void Use()
    {
        EffectManager.instance.AddEffect(myHolder, Effect.Type.SpellPower, spellPower, 0, myTarget);
    }
}
