using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public static EffectManager instance;

    public List<Effect> playerEffects;
    public List<Effect> enemyEffects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddEffect(bool player, Card giver, int amount, int duration)
    {
        Effect newEffect = new Effect()
        {
            effectGiver = ScriptableObject.CreateInstance<Card>()
        };

        newEffect.effectGiver = giver;
        newEffect.amount = amount;
        newEffect.duration = duration;

        if (player)
        {
            playerEffects.Add(newEffect);
        }
        else
        {
            enemyEffects.Add(newEffect);
        }
    }

    public void TriggerEffects()
    {

    }
}
