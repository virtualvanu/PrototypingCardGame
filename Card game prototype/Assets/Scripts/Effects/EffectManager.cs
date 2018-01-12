using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectManager : MonoBehaviour
{

    public static EffectManager instance;

    public List<Effect> activePlayerEffects = new List<Effect>();
    public List<Effect> activeEnemyEffects = new List<Effect>();
    [Space(10)]
    public List<Effect> passivePlayerEffects = new List<Effect>();
    public List<Effect> passiveEnemyEffects = new List<Effect>();
    [Space(10)]
    private List<Effect> endedEffects = new List<Effect>();
    [Space(10)]
    private List<Effect> endedPassiveEffects = new List<Effect>();

    [Header("Effect Icons")]
    public GameObject playerDotEffectIcon;
    public GameObject playerHotEffectIcon;
    public GameObject playerSpellpowerEffectIcon;
    public GameObject enemyDotEffectIcon;
    public GameObject enemyHotEffectIcon;
    public GameObject enemySpellpowerEffectIcon;

    [Header("Effect Popup")]
    public GameObject effectPopup;

    public Transform playerPopupSpawn;
    public Transform enemyPopupSpawn;

    public TextMeshProUGUI dotAmountText;
    public TextMeshProUGUI dotDurationText;
    public TextMeshProUGUI hotAmountText;
    public TextMeshProUGUI hotDurationText;
    public TextMeshProUGUI dmgIncreaseAmountText;

    [Header("TEST")]
    public List<Effect> activeEffects = new List<Effect>();
    public List<Effect> activePassiveEffects = new List<Effect>();
    public List<Effect> test_endedEffects = new List<Effect>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void TEST_AddEffect(CardHolder cardHolder, Effect.Type type, int amount, int duration)
    {
        Effect newEffect = new Effect
        {
            type = type,
            effectCard = cardHolder.card,

            amount = amount,
            duration = duration,

            effectReceiver = cardHolder.card.DetermineTarget(cardHolder)
        };

        activeEffects.Add(newEffect);

        TEST_CheckActiveEffects();
    }

    private void TEST_CheckActiveEffects()
    {
        playerDotEffectIcon.SetActive(false);
        playerHotEffectIcon.SetActive(false);
        playerSpellpowerEffectIcon.SetActive(false);

        enemyDotEffectIcon.SetActive(false);
        enemyHotEffectIcon.SetActive(false);
        enemySpellpowerEffectIcon.SetActive(false);

        foreach (Effect effect in activeEffects)
        {
            switch (effect.type)
            {
                case Effect.Type.DOT:

                    if (effect.effectReceiver == FightManager.instance.player)
                    {
                        playerDotEffectIcon.SetActive(true);
                    }
                    else if (effect.effectReceiver == FightManager.instance.enemy)
                    {
                        enemyDotEffectIcon.SetActive(true);
                    }
                    break;
                case Effect.Type.HOT:

                    if (effect.effectReceiver == FightManager.instance.player)
                    {
                        playerHotEffectIcon.SetActive(true);
                    }
                    else if (effect.effectReceiver == FightManager.instance.enemy)
                    {
                        enemyHotEffectIcon.SetActive(true);
                    }
                    break;
                case Effect.Type.SpellPower:

                    if (effect.effectReceiver == FightManager.instance.player)
                    {
                        playerSpellpowerEffectIcon.SetActive(false);
                    }
                    else if (effect.effectReceiver == FightManager.instance.enemy)
                    {
                        enemySpellpowerEffectIcon.SetActive(false);
                    }
                    break;
            }
        }
    }

    private IEnumerator TEST_TriggerEffects(bool passive)
    {
        foreach (Effect effect in activeEffects)
        {
            if (passive)
            {
                //if (FightManager.instance.turn == FightManager.Turn.player)
                //{
                //    if (effect.type == Effect.Type.SpellPower)
                //    {
                //        if (effect.effectReceiver == FightManager.instance.player)
                //        {
                //            effect.effectCard.TriggerEffect(effect.effectReceiver);
                //            effect.duration--;
                //        }
                //    }
                //}
                //else if (FightManager.instance.turn == FightManager.Turn.enemy)
                //{
                //    if (effect.type == Effect.Type.SpellPower)
                //    {
                //        if (effect.effectReceiver == FightManager.instance.enemy)
                //        {
                //            effect.effectCard.TriggerEffect(effect.effectReceiver);
                //            effect.duration--;
                //        }
                //    }
                //}

                test_endedEffects.Add(effect);
            }
            else
            {
                if (effect.type == Effect.Type.DOT || effect.type == Effect.Type.HOT)
                {
                    effect.effectCard.TriggerEffect(effect.effectReceiver);
                    effect.duration--;
                }
            }

            if (effect.duration == 0)
            {
                test_endedEffects.Add(effect);
            }

            yield return new WaitForSeconds(0.6f);
        }

        TEST_RemoveEndedEffects();
    }

    private void TEST_RemoveEndedEffects()
    {
        for (int i = 0; i < test_endedEffects.Count; i++)
        {
            activeEffects.Remove(test_endedEffects[i]);
        }

        TEST_CheckActiveEffects();
    }

    public void AddEffect(CardHolder cardHolder, Effect.Type type, int amount, int duration)
    {
        Effect newEffect = new Effect
        {
            type = type,
            effectCard = cardHolder.card,

            amount = amount,
            duration = duration,

            effectReceiver = cardHolder.card.DetermineTarget(cardHolder)
        };

        if (newEffect.effectReceiver == FightManager.instance.player)
        {
            activePlayerEffects.Add(newEffect);
        }
        else if (newEffect.effectReceiver == FightManager.instance.enemy)
        {
            activeEnemyEffects.Add(newEffect);
        }

        CheckActiveEffects();
        CheckActivePassiveEffects();
    }

    public void AddEffect(CardHolder cardHolder, Effect.Type type, int amount)
    {
        Effect newEffect = new Effect
        {
            type = type,
            effectCard = cardHolder.card,

            amount = amount,

            effectReceiver = cardHolder.card.DetermineTarget(cardHolder)
        };

        if (newEffect.effectReceiver == FightManager.instance.player)
        {
            passivePlayerEffects.Add(newEffect);
        }
        else if (newEffect.effectReceiver == FightManager.instance.enemy)
        {
            passiveEnemyEffects.Add(newEffect);
        }

        CheckActiveEffects();
        CheckActivePassiveEffects();
    }

    public void TriggerEffects()
    {
        StartCoroutine(TriggerAllyEffects());
        StartCoroutine(TriggerEnemyEffects());
    }

    private IEnumerator TriggerAllyEffects()
    {
        foreach (Effect effect in activePlayerEffects)
        {
            effect.effectCard.TriggerEffect(effect.effectReceiver);
            effect.duration--;

            if (effect.duration == 0)
            {
                endedEffects.Add(effect);
            }

            yield return new WaitForSeconds(0.6f);
        }

        RemoveEndedEffects();
    }

    private IEnumerator TriggerEnemyEffects()
    {
        foreach (Effect effect in activeEnemyEffects)
        {
            effect.effectCard.TriggerEffect(effect.effectReceiver);
            effect.duration--;

            if (effect.duration == 0)
            {
                endedEffects.Add(effect);
            }

            yield return new WaitForSeconds(0.6f);
        }

        RemoveEndedEffects();
    }

    public void TriggerPassiveEffects(Character target)
    {
        if (target == FightManager.instance.player)
        {
            foreach (Effect effect in passiveEnemyEffects)
            {
                endedPassiveEffects.Add(effect);
            }
        }
        else if (target == FightManager.instance.enemy)
        {
            foreach (Effect effect in passivePlayerEffects)
            {
                endedPassiveEffects.Add(effect);
            }
        }

        RemoveEndedPassiveEffects();
    }

    private void RemoveEndedEffects()
    {
        if (endedEffects.Count > 0)
        {
            for (int i = 0; i < endedEffects.Count; i++)
            {
                if (endedEffects[i].effectReceiver == FightManager.instance.player)
                {
                    activePlayerEffects.Remove(endedEffects[i]);
                }
                else if (endedEffects[i].effectReceiver == FightManager.instance.enemy)
                {
                    activeEnemyEffects.Remove(endedEffects[i]);
                }
            }
        }

        CheckActiveEffects();
    }

    private void RemoveEndedPassiveEffects()
    {
        if (endedPassiveEffects.Count > 0)
        {
            for (int i = 0; i < endedPassiveEffects.Count; i++)
            {
                if (endedPassiveEffects[i].effectReceiver == FightManager.instance.player)
                {
                    passivePlayerEffects.Remove(endedPassiveEffects[i]);
                }
                else if (endedPassiveEffects[i].effectReceiver == FightManager.instance.enemy)
                {
                    passiveEnemyEffects.Remove(endedPassiveEffects[i]);
                }
            }
        }

        CheckActivePassiveEffects();
    }

    private void CheckActiveEffects()
    {
        playerDotEffectIcon.SetActive(false);
        playerHotEffectIcon.SetActive(false);

        foreach (Effect effect in activePlayerEffects)
        {
            if (effect.effectCard.GetType() == typeof (Card_DOT))
            {
                playerDotEffectIcon.SetActive(true);
            }
            else if (effect.effectCard.GetType() == typeof(Card_HOT))
            {
                playerHotEffectIcon.SetActive(true);
            }
        }

        enemyDotEffectIcon.SetActive(false);
        enemyHotEffectIcon.SetActive(false);

        foreach (Effect effect in activeEnemyEffects)
        {
            if (effect.effectCard.GetType() == typeof(Card_DOT))
            {
                enemyDotEffectIcon.SetActive(true);
            }
            else if (effect.effectCard.GetType() == typeof(Card_HOT))
            {
                enemyHotEffectIcon.SetActive(true);
            }
        }
    }

    public void CheckActivePassiveEffects()
    {
        playerSpellpowerEffectIcon.SetActive(false);

        foreach (Effect effect in passivePlayerEffects)
        {
            if (effect.type == Effect.Type.SpellPower)
            {
                playerSpellpowerEffectIcon.SetActive(true);
            }
        }

        enemySpellpowerEffectIcon.SetActive(false);

        foreach (Effect effect in passiveEnemyEffects)
        {
            if (effect.type == Effect.Type.SpellPower)
            {
                enemySpellpowerEffectIcon.SetActive(true);
            }
        }
    }

    public int CheckForPassiveEffect(Effect.Type type, Character target)
    {
        List<Effect> toSearchThrough = new List<Effect>();
        int effectValue = 0;

        if (target == FightManager.instance.player)
        {
            toSearchThrough = passiveEnemyEffects;
        }
        else if (target == FightManager.instance.enemy)
        {
            toSearchThrough = passivePlayerEffects;
        }

        for (int i = 0; i < toSearchThrough.Count; i++)
        {
            if (toSearchThrough[i].type == type)
            {
                effectValue += toSearchThrough[i].amount;
            }
        }

        return effectValue;
    }

    public void ShowEffectPopup(bool isPlayer)
    {
        int dotAmount = 0;
        int dotDuration = 0;
        int hotAmount = 0;
        int hotDuration = 0;
        int dmgIncreaseAmount = 0;

        if (isPlayer)
        {
            effectPopup.transform.position = playerPopupSpawn.position;
            effectPopup.transform.SetParent(playerPopupSpawn);

            foreach (Effect effect in activePlayerEffects)
            {
                if (effect.effectCard.GetType() == typeof(Card_DOT))
                {
                    dotAmount += effect.amount;
                    dotDuration += effect.duration;
                }
                else if (effect.effectCard.GetType() == typeof(Card_HOT))
                {
                    hotAmount += effect.amount;
                    hotDuration += effect.duration;
                }
            }

            foreach (Effect effect in passivePlayerEffects)
            {
                if (effect.type == Effect.Type.SpellPower)
                {
                    dmgIncreaseAmount += effect.amount;
                }
            }
        }
        else
        {
            effectPopup.transform.position = enemyPopupSpawn.position;
            effectPopup.transform.SetParent(enemyPopupSpawn);

            foreach (Effect effect in activeEnemyEffects)
            {
                if (effect.effectCard.GetType() == typeof(Card_DOT))
                {
                    dotAmount += effect.amount;
                    dotDuration += effect.duration;
                }
                else if (effect.effectCard.GetType() == typeof(Card_HOT))
                {
                    hotAmount += effect.amount;
                    hotDuration += effect.duration;
                }
            }

            foreach (Effect effect in passiveEnemyEffects)
            {
                if (effect.type == Effect.Type.SpellPower)
                {
                    dmgIncreaseAmount += effect.amount;
                }
            }
        }

        dotAmountText.text = dotAmount.ToString();
        dotDurationText.text = dotDuration.ToString();
        hotAmountText.text = hotAmount.ToString();
        hotDurationText.text = hotDuration.ToString();
        dmgIncreaseAmountText.text = dmgIncreaseAmount.ToString();

        effectPopup.SetActive(true);
    }

    public void HideEffectPopup()
    {
        effectPopup.SetActive(false);
    }
}
