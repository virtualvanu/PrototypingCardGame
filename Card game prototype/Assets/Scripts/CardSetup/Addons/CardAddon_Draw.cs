using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_Draw : CardAddon
{

    [Header("Draw Addon Attributes")]
    public int amountToDraw;

    public override void Setup()
    {
        base.Setup();
    }

    public override void Use()
    {
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
