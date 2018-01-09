using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public CurrentDeck myDeck;
    public List<GameObject> cardholders = new List<GameObject>();
    public List<Card> cards = new List<Card>();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartEnemyTurn()
    {
        yield return new WaitForSeconds(Random.Range(1, 6));
        EnemyTurn();
    }

    public bool CardsAvailable()
    {
        cards.Clear();
        cardholders.Clear();
        for (int i = 0; i < myDeck.inHand.Count; i++)
        {
            if (myDeck.inHand[i].manaCost <= myDeck.myMana.currentMana)
            {
                cards.Add(myDeck.inHand[i]);
                cardholders.Add(myDeck.inhandie[i]);
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

    public void EnemyTurn()
    {
        if (CardsAvailable())
        {
            int card = Random.Range(0, cards.Count);
            cards[card].Use(cardholders[card].GetComponent<CardHolder>());
            for (int i = 0; i < cardholders.Count; i++)
            {
                if(myDeck.inhandie[i] == cardholders[card])
                {
                    
                    myDeck.inhandie.RemoveAt(i);
                    myDeck.inHand.RemoveAt(i);
                    myDeck.usedThisGame.Add(cards[card]);
                    //myDeck.myMana.c -= 
                    Destroy(cardholders[card]);
                    StartCoroutine(StartEnemyTurn());
                    //destroys card
                }
            }
            
        }
        else
        {
            print(CardsAvailable());
            FightManager.instance.EndTurn();
        }
    }
}
