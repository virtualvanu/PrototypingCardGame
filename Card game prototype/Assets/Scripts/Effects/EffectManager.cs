using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject playerDotEffectIcon;
    public GameObject playerHotEffectIcon;
    public GameObject playerDmgIncreaseEffectIcon;
    public GameObject enemyDotEffectIcon;
    public GameObject enemyHotEffectIcon;
    public GameObject enemyDmgIncreaseEffectIcon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddEffect(CardHolder giver, Effect.Type type, int amount, int duration)
    {
        Effect newEffect = new Effect
        {
            type = type,
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
        CheckActivePassiveEffects();
    }

    public void AddEffect(CardHolder giver, Effect.Type type, int amount)
    {
        Effect newEffect = new Effect
        {
            type = type,
            effectGiver = giver.card,

            amount = amount,

            damageTarget = giver.card.DetermineTarget(giver),
            damageTextTarget = giver.card.DetermineDamageTextTarget(giver)
        };

        if (newEffect.damageTarget == FightManager.instance.player)
        {
            passivePlayerEffects.Add(newEffect);
        }
        else if (newEffect.damageTarget == FightManager.instance.enemy)
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

    private void RemoveEndedPassiveEffects()
    {
        if (endedPassiveEffects.Count > 0)
        {
            for (int i = 0; i < endedPassiveEffects.Count; i++)
            {
                if (endedPassiveEffects[i].damageTarget == FightManager.instance.player)
                {
                    passivePlayerEffects.Remove(endedPassiveEffects[i]);
                }
                else if (endedPassiveEffects[i].damageTarget == FightManager.instance.enemy)
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

    public void CheckActivePassiveEffects()
    {
        playerDmgIncreaseEffectIcon.SetActive(false);

        foreach (Effect effect in passivePlayerEffects)
        {
            if (effect.type == Effect.Type.DamageIncrease)
            {
                playerDmgIncreaseEffectIcon.SetActive(true);
            }
        }

        enemyDmgIncreaseEffectIcon.SetActive(false);

        foreach (Effect effect in passiveEnemyEffects)
        {
            if (effect.type == Effect.Type.DamageIncrease)
            {
                enemyDmgIncreaseEffectIcon.SetActive(true);
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
}
