using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectManager : MonoBehaviour
{

    public static EffectManager instance;

    [Header("Effects")]
    public List<Effect> activeEffects = new List<Effect>();
    public List<Effect> endedEffects = new List<Effect>();

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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddEffect(CardHolder cardHolder, Effect.Type type, int amount, int duration, Character target)
    {
        Effect newEffect = new Effect
        {
            type = type,
            effectCard = cardHolder.card,

            amount = amount,
            duration = duration,

            effectReceiver = target
        };

        activeEffects.Add(newEffect);

        CheckActiveEffects();
    }

    public void TriggerEffects(bool passive)
    {
        StartCoroutine(TriggerEffectsRoutine(passive));
    }

    private IEnumerator TriggerEffectsRoutine(bool passive)
    {
        if (passive)
        {
            foreach (Effect effect in activeEffects)
            {
                if (effect.type == Effect.Type.SpellPower)
                {
                    if (effect.effectReceiver == FightManager.instance.player && FightManager.instance.turn == FightManager.Turn.player)
                    {
                        endedEffects.Add(effect);
                    }
                    else if (effect.effectReceiver == FightManager.instance.enemy && FightManager.instance.turn == FightManager.Turn.enemy)
                    {
                        endedEffects.Add(effect);
                    }
                }
            }
        }
        else
        {
            foreach (Effect effect in SortEffects(false))
            {
                if (effect.type == Effect.Type.DOT)
                {
                    for (int i = 0; i < effect.effectCard.dotAddons.Count; i++)
                    {
                        effect.effectCard.dotAddons[i].TriggerEffect(effect.effectReceiver);
                        effect.duration--;

                        if (effect.duration == 0)
                        {
                            endedEffects.Add(effect);
                        }

                        yield return new WaitForSeconds(0.6f);
                    }
                }

                if (effect.type == Effect.Type.HOT)
                {
                    for (int i = 0; i < effect.effectCard.hotAddons.Count; i++)
                    {
                        effect.effectCard.hotAddons[i].TriggerEffect(effect.effectReceiver);
                        effect.duration--;

                        if (effect.duration == 0)
                        {
                            endedEffects.Add(effect);
                        }

                        yield return new WaitForSeconds(0.6f);
                    }
                }
            }

            foreach (Effect effect in SortEffects(true))
            {
                if (effect.type == Effect.Type.DOT)
                {
                    for (int i = 0; i < effect.effectCard.dotAddons.Count; i++)
                    {
                        effect.effectCard.dotAddons[i].TriggerEffect(effect.effectReceiver);
                        effect.duration--;

                        if (effect.duration == 0)
                        {
                            endedEffects.Add(effect);
                        }

                        yield return new WaitForSeconds(0.6f);
                    }
                }

                if (effect.type == Effect.Type.HOT)
                {
                    for (int i = 0; i < effect.effectCard.hotAddons.Count; i++)
                    {
                        effect.effectCard.hotAddons[i].TriggerEffect(effect.effectReceiver);
                        effect.duration--;

                        if (effect.duration == 0)
                        {
                            endedEffects.Add(effect);
                        }

                        yield return new WaitForSeconds(0.6f);
                    }
                }
            }
        }

        RemoveEndedEffects();

        // Triggering effects in order:

        //foreach (Effect effect in activeEffects)
        //{
        //    if (passive)
        //    {
        //        if (effect.type == Effect.Type.SpellPower)
        //        {
        //            if (effect.effectReceiver == FightManager.instance.player && FightManager.instance.turn == FightManager.Turn.player)
        //            {
        //                endedEffects.Add(effect);
        //            }
        //            else if (effect.effectReceiver == FightManager.instance.enemy && FightManager.instance.turn == FightManager.Turn.enemy)
        //            {
        //                endedEffects.Add(effect);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (effect.type == Effect.Type.DOT || effect.type == Effect.Type.HOT)
        //        {
        //            effect.effectCard.TriggerEffect(effect.effectReceiver);
        //            effect.duration--;

        //            if (effect.duration == 0)
        //            {
        //                endedEffects.Add(effect);
        //            }

        //            yield return new WaitForSeconds(0.6f);
        //        }
        //    }
        //}
    }

    private List<Effect> SortEffects(bool player)
    {
        List<Effect> activePlayerEffects = new List<Effect>();
        List<Effect> activeEnemyEffects = new List<Effect>();

        foreach (Effect effect in activeEffects)
        {
            if (effect.type == Effect.Type.DOT || effect.type == Effect.Type.HOT)
            {
                if (player)
                {
                    if (effect.effectReceiver == FightManager.instance.player)
                    {
                        activePlayerEffects.Add(effect);
                    }
                }
                else
                {
                    if (effect.effectReceiver == FightManager.instance.enemy)
                    {
                        activeEnemyEffects.Add(effect);
                    }
                }
            }
        }

        if (player)
        {
            return activePlayerEffects;
        }
        else
        {
            return activeEnemyEffects;
        }
    }

    private void CheckActiveEffects()
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
                        playerSpellpowerEffectIcon.SetActive(true);
                    }
                    else if (effect.effectReceiver == FightManager.instance.enemy)
                    {
                        enemySpellpowerEffectIcon.SetActive(true);
                    }
                    break;
            }
        }
    }

    private void RemoveEndedEffects()
    {
        for (int i = 0; i < endedEffects.Count; i++)
        {
            activeEffects.Remove(endedEffects[i]);
        }

        CheckActiveEffects();
    }

    public int CheckForPassiveEffect(Effect.Type type, Character effectReceiver)
    {
        int effectValue = 0;

        foreach (Effect effect in activeEffects)
        {
            if (effect.type == type)
            {
                if (effect.effectReceiver == effectReceiver)
                {
                    effectValue += effect.amount;
                }
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
        int spellpowerAmount = 0;

        if (isPlayer)
        {
            effectPopup.transform.position = playerPopupSpawn.position;
            effectPopup.transform.SetParent(playerPopupSpawn);

            foreach (Effect effect in activeEffects)
            {
                if (effect.effectReceiver == FightManager.instance.player)
                {
                    if (effect.type == Effect.Type.DOT)
                    {
                        dotAmount += effect.amount;
                        dotDuration += effect.duration;
                    }
                    else if (effect.type == Effect.Type.HOT)
                    {
                        hotAmount += effect.amount;
                        hotDuration += effect.duration;
                    }
                    else if (effect.type == Effect.Type.SpellPower)
                    {
                        spellpowerAmount += effect.amount;
                    }
                }
            }
        }
        else
        {
            effectPopup.transform.position = enemyPopupSpawn.position;
            effectPopup.transform.SetParent(enemyPopupSpawn);

            foreach (Effect effect in activeEffects)
            {
                if (effect.effectReceiver == FightManager.instance.enemy)
                {
                    if (effect.type == Effect.Type.DOT)
                    {
                        dotAmount += effect.amount;
                        dotDuration += effect.duration;
                    }
                    else if (effect.type == Effect.Type.HOT)
                    {
                        hotAmount += effect.amount;
                        hotDuration += effect.duration;
                    }
                    else if (effect.type == Effect.Type.SpellPower)
                    {
                        spellpowerAmount += effect.amount;
                    }
                }
            }
        }

        dotAmountText.text = dotAmount.ToString();
        dotDurationText.text = dotDuration.ToString();
        hotAmountText.text = hotAmount.ToString();
        hotDurationText.text = hotDuration.ToString();
        dmgIncreaseAmountText.text = spellpowerAmount.ToString();

        if (spellpowerAmount >= 0)
        {
            dmgIncreaseAmountText.color = new Color32(0, 214, 37, 255);
        }
        else
        {
            dmgIncreaseAmountText.color = new Color32(244, 0, 0, 255);
        }

        effectPopup.SetActive(true);
    }

    public void HideEffectPopup()
    {
        effectPopup.SetActive(false);
    }
}
