using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OLDCards/LifeTap")]
public class Card_LifeTap : Card
{

    public enum DamageTarget
    {
        Self,
        Opponent
    }
    [Header("LifeTap Card Attributes")]
    public DamageTarget damageTarget;
    [Space(10)]
    public int damage;
    public int amountToDraw;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        //myHolder.CreateAttribute(CardAttribute.Type.Damage, damage);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        Character myTarget = DetermineTarget(myHolder);

        switch (damageTarget)
        {
            case DamageTarget.Self:

                myTarget.currentHealth -= damage;
                FightManager.instance.SpawnDamageText(damage, true, myTarget);
                break;
            case DamageTarget.Opponent:

                GetOtherTarget(myTarget).currentHealth -= damage;
                FightManager.instance.SpawnDamageText(damage, true, GetOtherTarget(myTarget));
                break;
        }

        if (myTarget == FightManager.instance.player)
        {
            FightManager.instance.StartCoroutine(FightManager.instance.myDeck.GetNewCard(amountToDraw));
        }
        else if (myTarget == FightManager.instance.enemy)
        {
            FightManager.instance.StartCoroutine(FightManager.instance.enemyCurrentDeck.GetNewCard(amountToDraw));
        }
    }
}
