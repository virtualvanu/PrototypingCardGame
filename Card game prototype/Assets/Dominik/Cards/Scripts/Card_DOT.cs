using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DOT")]
public class Card_DOT : Card
{

    [Header("DOT Card Attributes")]
    public int damage;
    public int duration;

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        myHolder.CreateAttribute(2, damage);
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

                        FightManager.instance.enemy.currentHealth -= damage;
                        break;
                    case Target.Enemy:

                        FightManager.instance.player.currentHealth -= damage;
                        break;
                    case Target.Both:

                        FightManager.instance.enemy.currentHealth -= damage;
                        FightManager.instance.player.currentHealth -= damage;
                        break;
                }
                break;
            case CardHolder.Side.Player:

                switch (target)
                {
                    case Target.Ally:

                        FightManager.instance.player.currentHealth -= damage;
                        break;
                    case Target.Enemy:

                        FightManager.instance.enemy.currentHealth -= damage;
                        break;
                    case Target.Both:

                        FightManager.instance.player.currentHealth -= damage;
                        FightManager.instance.enemy.currentHealth -= damage;
                        break;
                }
                break;
        }

        Debug.Log("DOT card did " + damage + " damage for " + duration + " rounds");

    }
}
