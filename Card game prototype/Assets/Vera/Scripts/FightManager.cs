using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {
    public static FightManager instance;
    public Character player;
    public Character enemy;
    public List<Card> playerDeck;
    public List<Card> enemyDeck;
    public CurrentDeck myDeck;
    public CurrentDeck enemyCurrentDeck;
    public static bool inFight;

    public Image playerHealth;
    public Image enemyHealth;

    public enum Turn
    {
        player,
        enemy
    }
    public Turn turn;

    private void Update()
    {
        playerHealth.fillAmount = (float)player.currentHealth / player.maxHealth;
        enemyHealth.fillAmount = (float)enemy.currentHealth / enemy.maxHealth;
    }

    private void Awake()
    {
        inFight = true;
        if(instance == null)
        {
            instance = this;
        }
        print(playerDeck.Count);
        inFight = true;
        StartCoroutine(SetPlayerDeck());
    }

    public IEnumerator SetPlayerDeck()
    {
        yield return new WaitForSeconds(0.5f);
        myDeck.remainingDeck = playerDeck;
        enemyCurrentDeck.remainingDeck = enemyDeck;
        print(playerDeck.Count);
        myDeck.Setup();
    }
}
