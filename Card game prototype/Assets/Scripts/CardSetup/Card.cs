using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{

    List<int> orderList = new List<int>();

    public enum Target
    {
        Self,
        Opponent
    }
    [Header("General Variables")]
    private Target target;

    public string cardName;
    public int manaCost;
    public Sprite icon;

    public enum Category
    {
        Damage,
        Heal,
        DOT,
        HOT,
        Buffs,
        Other
    }
    public List<Category> categories = new List<Category>();

    [Header("Card Functionality")]
    public List<CardAddon_Damage> damageAddons = new List<CardAddon_Damage>();
    public List<CardAddon_Heal> healAddons = new List<CardAddon_Heal>();
    public List<CardAddon_DOT> dotAddons = new List<CardAddon_DOT>();
    public List<CardAddon_HOT> hotAddons = new List<CardAddon_HOT>();
    public List<CardAddon_SpellPower> spellPowerAddons = new List<CardAddon_SpellPower>();
    public List<CardAddon_Draw> drawAddons = new List<CardAddon_Draw>();
    public List<CardAddon_StealCard> stealCardAddons = new List<CardAddon_StealCard>();

    public virtual void Setup(CardHolder myHolder)
    {
        #region Setting up the addons
        for (int i = 0; i < damageAddons.Count; i++)
        {
            damageAddons[i].myHolder = myHolder;
            damageAddons[i].Setup();

            //orderList.Add(damageAddons[i].order);
        }

        for (int i = 0; i < healAddons.Count; i++)
        {
            healAddons[i].myHolder = myHolder;
            healAddons[i].Setup();

            //orderList.Add(healAddons[i].order);
        }

        for (int i = 0; i < dotAddons.Count; i++)
        {
            dotAddons[i].myHolder = myHolder;
            dotAddons[i].Setup();

            //orderList.Add(dotAddons[i].order);
        }

        for (int i = 0; i < hotAddons.Count; i++)
        {
            hotAddons[i].myHolder = myHolder;
            hotAddons[i].Setup();

            //orderList.Add(hotAddons[i].order);
        }

        for (int i = 0; i < spellPowerAddons.Count; i++)
        {
            spellPowerAddons[i].myHolder = myHolder;
            spellPowerAddons[i].Setup();

            //orderList.Add(spellPowerAddons[i].order);
        }

        for (int i = 0; i < drawAddons.Count; i++)
        {
            drawAddons[i].myHolder = myHolder;
            drawAddons[i].Setup();

            //orderList.Add(drawAddons[i].order);
        }

        for (int i = 0; i < stealCardAddons.Count; i++)
        {
            stealCardAddons[i].myHolder = myHolder;
            stealCardAddons[i].Setup();

            //orderList.Add(stealCardAddons[i].order);
        }
        //orderList.Sort();
        #endregion
    }

    public virtual void Use(CardHolder myHolder)
    {
        myHolder.DissolveCard();

        #region Testing Orders
        //for (int i = 0; i < orderList.Count; i++)
        //{
        //    for (int ii = 0; ii < damageAddons.Count; ii++)
        //    {
        //        if (damageAddons[ii].order == i)
        //        {
        //            damageAddons[ii].Use();
        //        }
        //    }

        //    for (int ii = 0; ii < healAddons.Count; ii++)
        //    {
        //        if (healAddons[ii].order == i)
        //        {
        //            healAddons[ii].Use();
        //        }
        //    }

        //    for (int ii = 0; ii < dotAddons.Count; ii++)
        //    {
        //        if (dotAddons[ii].order == i)
        //        {
        //            dotAddons[ii].Use();
        //        }
        //    }

        //    for (int ii = 0; ii < hotAddons.Count; ii++)
        //    {
        //        if (hotAddons[ii].order == i)
        //        {
        //            hotAddons[ii].Use();
        //        }
        //    }
        //}
        #endregion

        for (int i = 0; i < damageAddons.Count; i++)
        {
            damageAddons[i].Use();
        }

        for (int i = 0; i < healAddons.Count; i++)
        {
            healAddons[i].Use();
        }

        for (int i = 0; i < dotAddons.Count; i++)
        {
            dotAddons[i].Use();
        }

        for (int i = 0; i < hotAddons.Count; i++)
        {
            hotAddons[i].Use();
        }

        for (int i = 0; i < spellPowerAddons.Count; i++)
        {
            spellPowerAddons[i].Use();
        }

        for (int i = 0; i < drawAddons.Count; i++)
        {
            drawAddons[i].Use();
        }

        for (int i = 0; i < stealCardAddons.Count; i++)
        {
            stealCardAddons[i].Use();
        }
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
