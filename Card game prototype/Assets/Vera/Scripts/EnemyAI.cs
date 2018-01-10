using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    public CurrentDeck myDeck;
    public List<GameObject> cardholders = new List<GameObject>();
    public List<Card> cards = new List<Card>();

    public Button endTurnButton;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartEnemyTurn()
    {
        yield return new WaitForSeconds(Random.Range(1, 6));
        StartCoroutine(EnemyTurn());
    }

    public bool CardsAvailable()
    {
        bool fullhealth = false;
        if(FightManager.instance.enemy.currentHealth == FightManager.instance.enemy.maxHealth)
        {
            fullhealth = true;
        }
        if(Random.Range(0,100) < 10)
        {
            return false;
        }
        cards.Clear();
        cardholders.Clear();
        for (int i = 0; i < myDeck.inHand.Count; i++)
        {
            if(fullhealth == true)
            {
                if (myDeck.inHand[i].manaCost <= myDeck.myMana.currentMana && myDeck.inHand[i].GetType() != typeof(Card_Heal))
                {
                    cards.Add(myDeck.inHand[i]);
                    cardholders.Add(myDeck.inhandie[i]);
                }
            }
            else
            {
                if (myDeck.inHand[i].manaCost <= myDeck.myMana.currentMana)
                {
                    cards.Add(myDeck.inHand[i]);
                    cardholders.Add(myDeck.inhandie[i]);
                }
            }

        }
        if(cards.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator EnemyTurn()
    {
        print(CardsAvailable());
        if (CardsAvailable())
        {
            int card = Random.Range(0, cards.Count);

            cardholders[card].GetComponent<Animator>().SetTrigger("Highlighted");
            yield return new WaitForSeconds(cardholders[card].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            cardholders[card].GetComponent<Animator>().SetTrigger("Pressed");
            yield return new WaitForSeconds(2f);
            cards[card].Use(cardholders[card].GetComponent<CardHolder>());

            for (int i = 0; i < myDeck.inHand.Count; i++)
            {
                if (myDeck.inHand[i] == cards[card])
                {
                    myDeck.inhandie.RemoveAt(i);
                    myDeck.inHand.RemoveAt(i);
                    myDeck.usedThisGame.Add(cards[card]);
                    myDeck.myMana.CheckMana(cards[card].manaCost);
                    //Destroy(cardholders[card]); // de card wordt al gedestroyed in de Use() na het dissolven
                    StartCoroutine(StartEnemyTurn());
                    yield break;
                    //destroys card
                }
            }
            
        }
        else
        {
            endTurnButton.GetComponent<Animator>().SetTrigger("Highlighted");
            endTurnButton.onClick.Invoke();
            endTurnButton.GetComponent<Animator>().SetTrigger("Pressed");
        }
    }
}
