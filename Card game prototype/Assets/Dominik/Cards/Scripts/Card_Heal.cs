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

        myHolder.CreateAttribute(1, healAmount);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        switch (myHolder.side)
        {
            case CardHolder.Side.Enemy:

                switch (target)
                {
                    case Target.Ally:

                        FightManager.instance.enemy.currentHealth += healAmount;
                        break;
                    case Target.Enemy:

                        FightManager.instance.player.currentHealth += healAmount;
                        break;
                    case Target.Both:

                        FightManager.instance.enemy.currentHealth += healAmount;
                        FightManager.instance.player.currentHealth += healAmount;
                        break;
                }
                break;
            case CardHolder.Side.Player:

                switch (target)
                {
                    case Target.Ally:

                        FightManager.instance.player.currentHealth += healAmount;
                        break;
                    case Target.Enemy:

                        FightManager.instance.enemy.currentHealth += healAmount;
                        break;
                    case Target.Both:

                        FightManager.instance.player.currentHealth += healAmount;
                        FightManager.instance.enemy.currentHealth += healAmount;
                        break;
                }
                break;
        }

        Debug.Log("Heal card healed " + healAmount + " health");

    }
}
