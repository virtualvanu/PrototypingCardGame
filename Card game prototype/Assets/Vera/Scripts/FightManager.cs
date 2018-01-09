using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [Header("Damage Text")]
    public GameObject damageText;
    [Space(10)]
    public Color damageColor;
    public Color healColor;


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
        StartGame();
    }

    public void EndTurn()
    {
        if(turn == Turn.player)
        {
            turn = Turn.enemy;
            enemyCurrentDeck.myMana.StartTurn();
            enemyCurrentDeck.GetNewCard();
        }
        else
        {
            turn = Turn.player;
            myDeck.myMana.StartTurn();
            myDeck.GetNewCard();
        }
    }

    public void StartGame()
    {
        enemyCurrentDeck.Setup();
        myDeck.Setup();

        int i = Random.Range(0, 2);
        if(i == 0)
        {
            turn = Turn.player;
            myDeck.myMana.StartTurn();
        }
        else
        {
            turn = Turn.enemy;
            enemyCurrentDeck.myMana.StartTurn();
            print("TEst Mana");
        }
    }

    public void SpawnDamageText(int value, bool damage, Transform spawn)
    {
        GameObject newDamageText;

        newDamageText = Instantiate(damageText, spawn.transform);

        DamageText damageTextComponent = newDamageText.GetComponent<DamageText>();

        if (damage)
        {
            damageTextComponent.damage = true;
            damageTextComponent.text.text = "-" + value;

            damageTextComponent.text.color = damageColor;
        }
        else
        {
            damageTextComponent.damage = false;
            damageTextComponent.text.text = "+" + value;

            damageTextComponent.text.color = healColor;
        }
    }
}
