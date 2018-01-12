using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : ScriptableObject
{

    public enum Target
    {
        Self,
        Opponent
    }
    [Header("General Variables")]
    public Target target;

    public string cardName;

    public int manaCost;

    public int level;

    public Sprite icon;

    public virtual void Setup(CardHolder myHolder)
    {

    }

    public virtual void Use(CardHolder myHolder)
    {
        myHolder.DissolveCard();
    }

    public virtual void TriggerEffect(Character target)
    {

    }

    public Character DetermineTarget(CardHolder myHolder)
    {
        Character myTarget = null;

        switch (myHolder.side)
        {
            case CardHolder.Side.Enemy:

                switch (target)
                {
                    case Target.Self:

                        myTarget = FightManager.instance.enemy;
                        break;
                    case Target.Opponent:

                        myTarget = FightManager.instance.player;
                        break;
                }
                break;
            case CardHolder.Side.Player:

                switch (target)
                {
                    case Target.Self:

                        myTarget = FightManager.instance.player;
                        break;
                    case Target.Opponent:

                        myTarget = FightManager.instance.enemy;
                        break;
                }
                break;
        }

        return myTarget;
    }

    public Character GetOtherTarget(Character target)
    {
        if (target == FightManager.instance.player)
        {
            return FightManager.instance.enemy;
        }
        else if (target == FightManager.instance.enemy)
        {
            return FightManager.instance.player;
        }
        else
        {
            return null;
        }
    }
}
