using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {
    public static FightManager instance;
    public Character player;
    public Character enemy;
    public List<Card> playerDeck;
    public List<Card> enemyDeck;
    public CurrentDeck myDeck;
    public enum Turn
    {
        player,
        enemy
    }
    public Turn turn;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        SetPlayerDeck(playerDeck);
    }

    public void SetPlayerDeck(List<Card> cards)
    {
        myDeck.remainingDeck = cards;
    }
}
