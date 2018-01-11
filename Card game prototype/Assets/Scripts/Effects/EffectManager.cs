using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public static EffectManager instance;

    public List<Effect> activePlayerEffects = new List<Effect>();
    public List<Effect> activeEnemyEffects = new List<Effect>();
    [Space(10)]
    private List<Effect> endedEffects = new List<Effect>();

    public GameObject playerDotEffectIcon;
    public GameObject playerHotEffectIcon;
    public GameObject enemyDotEffectIcon;
    public GameObject enemyHotEffectIcon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddEffect(CardHolder giver, int amount, int duration)
    {
        Effect newEffect = new Effect
        {
            effectGiver = giver.card,

            amount = amount,
            duration = duration,

            damageTarget = giver.card.DetermineTarget(giver),
            damageTextTarget = giver.card.DetermineDamageTextTarget(giver)
        };

        if (newEffect.damageTarget == FightManager.instance.player)
        {
            activePlayerEffects.Add(newEffect);
        }
        else if (newEffect.damageTarget == FightManager.instance.enemy)
        {
            activeEnemyEffects.Add(newEffect);
        }

        CheckActiveEffects();
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
            effect.effectGiver.TriggerEffect(effect.damageTarget, effect.damageTextTarget);
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
            effect.effectGiver.TriggerEffect(effect.damageTarget, effect.damageTextTarget);
            effect.duration--;

            if (effect.duration == 0)
            {
                endedEffects.Add(effect);
            }

            yield return new WaitForSeconds(0.6f);
        }

        RemoveEndedEffects();
    }

    private void RemoveEndedEffects()
    {
        if (endedEffects.Count > 0)
        {
            for (int i = 0; i < endedEffects.Count; i++)
            {
                if (endedEffects[i].damageTarget == FightManager.instance.player)
                {
                    activePlayerEffects.Remove(endedEffects[i]);
                }
                else if (endedEffects[i].damageTarget == FightManager.instance.enemy)
                {
                    activeEnemyEffects.Remove(endedEffects[i]);
                }
            }
        }

        CheckActiveEffects();
    }

    private void CheckActiveEffects()
    {
        playerDotEffectIcon.SetActive(false);
        playerHotEffectIcon.SetActive(false);

        foreach (Effect effect in activePlayerEffects)
        {
            if (effect.effectGiver.GetType() == typeof (Card_DOT))
            {
                playerDotEffectIcon.SetActive(true);
            }
            else if (effect.effectGiver.GetType() == typeof(Card_HOT))
            {
                playerHotEffectIcon.SetActive(true);
            }
        }

        enemyDotEffectIcon.SetActive(false);
        enemyHotEffectIcon.SetActive(false);

        foreach (Effect effect in activeEnemyEffects)
        {
            if (effect.effectGiver.GetType() == typeof(Card_DOT))
            {
                enemyDotEffectIcon.SetActive(true);
            }
            else if (effect.effectGiver.GetType() == typeof(Card_HOT))
            {
                enemyHotEffectIcon.SetActive(true);
            }
        }
    }
}
