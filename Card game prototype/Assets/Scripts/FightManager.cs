using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour {
    public Character testPlayer;
    public Character testEnemy;
    [Header("realshiz")]
    public static FightManager instance;
    public Character player;
    public Character enemy;
    public List<Card> playerDeck;
    public List<Card> enemyDeck;
    public CurrentDeck myDeck;
    public CurrentDeck enemyCurrentDeck;
    public static bool inFight;
    public EnemyAI enemyAI;

    public Image playerHealth;
    public GameObject playerHealthObject;
    public Image enemyHealth;
    public GameObject enemyHealthObject;

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

    [Header("Color Lerping")]
    public float colorLerpSpeed;
    public float scaleLerpSpeed;
    [Space(10)]
    public Color defaultColor;
    public Color lerpColor;

    [Header("Health Popup")]
    public GameObject healthPopup;
    public TextMeshProUGUI healthPopupText;
    private bool showHealthPopup;

    private void Update()
    {
        playerHealth.fillAmount = (float)player.currentHealth / player.maxHealth;
        enemyHealth.fillAmount = (float)enemy.currentHealth / enemy.maxHealth;

        if (turn == Turn.player)
        {
            playerHealth.color = Color.Lerp(defaultColor, lerpColor, Mathf.PingPong(Time.time * colorLerpSpeed, 1));
            enemyHealth.color = defaultColor;

            playerHealthObject.transform.localScale = new Vector3(Mathf.PingPong(Time.time * scaleLerpSpeed, 0.1f) + 1f, Mathf.PingPong(Time.time * scaleLerpSpeed, 0.1f) + 1f);
        }
        else
        {
            enemyHealth.color = Color.Lerp(defaultColor, lerpColor, Mathf.PingPong(Time.time * colorLerpSpeed, 1));
            playerHealth.color = defaultColor;

            enemyHealthObject.transform.localScale = new Vector3(Mathf.PingPong(Time.time * scaleLerpSpeed, 0.1f) + 1f, Mathf.PingPong(Time.time * scaleLerpSpeed, 0.1f) + 1f);
        }

        if (showHealthPopup)
        {
            healthPopup.transform.position = Input.mousePosition;
        }

    }

    private void Awake()
    {
        Time.timeScale = 1;

        inFight = true;
        if(instance == null)
        {
            instance = this;
        }
        //StartGame(testPlayer, testEnemy);
        StartCoroutine(SetPlayerDeck());
    }

    public IEnumerator SetPlayerDeck()
    {
        yield return new WaitForSeconds(0.5f);
        StartGame(testPlayer, testEnemy);
        //StartGame();
    }

    public void EndTurn()
    {
        if(turn == Turn.player)
        {
            turn = Turn.enemy;
            enemyCurrentDeck.myMana.StartTurn();
            enemyCurrentDeck.GetNewCard(1);
            enemyAI.StartCoroutine(enemyAI.StartEnemyTurn());
        }
        EffectManager.instance.TriggerEffects();
    }

    public void EndTurnEnemy()
    {
        turn = Turn.player;
        myDeck.myMana.StartTurn();
        myDeck.GetNewCard(1);
        EffectManager.instance.TriggerEffects();
    }

    public void StartGame(Character playerChar,Character enemyChar)
    {
        enemy = enemyChar;
        player = playerChar;
        enemyCurrentDeck.remainingDeck = new List<Card>(enemy.deck);
        myDeck.remainingDeck = new List<Card>(player.deck);
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
            enemyAI.StartCoroutine(enemyAI.StartEnemyTurn());
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

    public void ShowHealth(bool isPlayer)
    {
        showHealthPopup = true;

        if (isPlayer)
        {
            healthPopupText.text = "Health: " + player.currentHealth;
        }
        else
        {
            healthPopupText.text = "Health: " + enemy.currentHealth;
        }

        healthPopup.SetActive(true);
    }

    public void HideHealth()
    {
        showHealthPopup = false;

        healthPopup.SetActive(false);
    }
}
