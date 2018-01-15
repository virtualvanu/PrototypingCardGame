using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon
{

    [HideInInspector]
    public CardHolder myHolder;
    [HideInInspector]
    public Character myTarget;

    //public int order;

    public enum Target
    {
        Self,
        Opponent
    }
    [Header("General Attributes")]
    public Target target;

    public virtual void Setup()
    {
        #region Setting the target
        if (myHolder.side == CardHolder.Side.Enemy)
        {
            if (target == Target.Self)
            {
                myTarget = FightManager.instance.player;
            }
            else if (target == Target.Opponent)
            {
                myTarget = FightManager.instance.enemy;
            }
        }
        else if (myHolder.side == CardHolder.Side.Player)
        {
            if (target == Target.Self)
            {
                myTarget = FightManager.instance.enemy;
            }
            else if (target == Target.Opponent)
            {
                myTarget = FightManager.instance.player;
            }
        }
        #endregion
    }

    public virtual void Use()
    {

    }

    public virtual void TriggerEffect(Character target)
    {

    }

    protected Character GetOtherTarget()
    {
        if (myTarget == FightManager.instance.player)
        {
            return FightManager.instance.enemy;
        }
        else
        {
            return FightManager.instance.player;
        }
    }
}
