using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_Draw : CardAddon
{

    [Header("Draw Addon Attributes")]
    public int amountToDraw;

    public enum DrawFrom
    {
        Deck,
        AllCards
    }
    public DrawFrom drawFrom;

    public override void Setup()
    {
        base.Setup();

        myHolder.CreateAttribute(CardAttribute.Type.Draw, amountToDraw, myTarget);
    }

    public override void Use()
    {
        if (drawFrom == DrawFrom.Deck)
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
        else if (drawFrom == DrawFrom.AllCards)
        {
            for (int i = 0; i < amountToDraw; i++)
            {
                AllCards allCardsScript = Object.FindObjectOfType<AllCards>();
                Card randomCard = allCardsScript.allCards[Random.Range(0, allCardsScript.allCards.Count)];

                if (myTarget == FightManager.instance.player)
                {
                    FightManager.instance.myDeck.GetSpecificCard(randomCard);
                }
                else if (myTarget == FightManager.instance.enemy)
                {
                    FightManager.instance.enemyCurrentDeck.GetSpecificCard(randomCard);
                }
            }
        }
    }
}
