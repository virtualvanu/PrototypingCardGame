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
    public static bool inFight;
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
        print(playerDeck.Count);
        StartCoroutine(SetPlayerDeck());
    }

    public IEnumerator SetPlayerDeck()
    {
        yield return new WaitForSeconds(0.5f);
        myDeck.remainingDeck = playerDeck;
        print(playerDeck.Count);
        myDeck.Setup();
    }
}
