using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/LifeTap")]
public class Card_LifeTap : Card
{

    [Header("LifeTap Card Attributes")]
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

        myTarget.currentHealth -= damage;
        FightManager.instance.SpawnDamageText(damage, true, myTarget);

        FightManager.instance.StartCoroutine(FightManager.instance.myDeck.GetNewCard(amountToDraw));
    }
}
