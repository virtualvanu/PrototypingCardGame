using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{

    public string characterName;

    [Header("Stats")]
    public int maxHealth;
    public int currentHealth;
    [Space(10)]
    public int shieldHealth;

    [Header("Properties")]
    public List<Card> deck;

    public enum Type
    {
        Enemy,
        Player
    }
    public Type type;


    public void SetUp()
    {
        switch (type)
        {
            case Type.Enemy:

                //FightManager.instance.enemy = this;
                //FightManager.instance.enemyDeck = new List<Card>(deck);
                break;
            case Type.Player:

                //FightManager.instance.player = this;
                //FightManager.instance.playerDeck = new List<Card>(deck);
                break;
        }

        currentHealth = maxHealth;
    }
}
