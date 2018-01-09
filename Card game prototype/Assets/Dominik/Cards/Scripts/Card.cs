using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : ScriptableObject
{

    public enum Target
    {
        Ally,
        Enemy,
        Both
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
        Debug.Log("Used the card: " + cardName);

        myHolder.DissolveCard();

        // remove from hand
    }

    public virtual void TriggerEffect(Character target, Transform damageTextPos)
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
                    case Target.Ally:

                        myTarget = FightManager.instance.enemy;
                        break;
                    case Target.Enemy:

                        myTarget = FightManager.instance.player;
                        break;
                    case Target.Both:

                        //myTarget = FightManager.instance.enemy;
                        //myTarget = FightManager.instance.player;
                        break;
                }
                break;
            case CardHolder.Side.Player:

                switch (target)
                {
                    case Target.Ally:

                        myTarget = FightManager.instance.player;
                        break;
                    case Target.Enemy:

                        myTarget = FightManager.instance.enemy;
                        break;
                    case Target.Both:

                        //myTarget = FightManager.instance.player;
                        //myTarget = FightManager.instance.enemy;
                        break;
                }
                break;
        }

        return myTarget;
    }

    public Transform DetermineDamageTextTarget(CardHolder myHolder)
    {
        Transform myTarget = null;

        switch (myHolder.side)
        {
            case CardHolder.Side.Enemy:

                switch (target)
                {
                    case Target.Ally:

                        myTarget = FightManager.instance.enemyHealth.transform;
                        break;
                    case Target.Enemy:

                        myTarget = FightManager.instance.playerHealth.transform;
                        break;
                    case Target.Both:

                        //myTarget = FightManager.instance.enemy;
                        //myTarget = FightManager.instance.player;
                        break;
                }
                break;
            case CardHolder.Side.Player:

                switch (target)
                {
                    case Target.Ally:

                        myTarget = FightManager.instance.playerHealth.transform;
                        break;
                    case Target.Enemy:

                        myTarget = FightManager.instance.enemyHealth.transform;
                        break;
                    case Target.Both:

                        //myTarget = FightManager.instance.player;
                        //myTarget = FightManager.instance.enemy;
                        break;
                }
                break;
        }

        return myTarget;
    }
}
