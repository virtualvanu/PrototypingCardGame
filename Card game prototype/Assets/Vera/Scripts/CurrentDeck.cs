﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDeck : MonoBehaviour {
    public List<Card> remainingDeck = new List<Card>();
    public List<Card> inHand = new List<Card>();
    public List<GameObject> inhandie = new List<GameObject>();
    public List <Card> usedThisGame = new List<Card>();
    public GameObject cardPrefab;
    public ManaCount myMana;

    public int startAmount;

    public enum Side
    {
        player,
        enemy
    }

    public Side side;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetNewCard();
        }
	}
    
    public void GetNewCard()
    {
        if (remainingDeck.Count != 0)
        {
            int rand = Random.Range(0, remainingDeck.Count);
            inHand.Add(remainingDeck[rand]);

            GameObject nc = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            inhandie.Add(nc);
            nc.transform.SetParent(gameObject.transform);
            CardHolder newC = nc.GetComponent<CardHolder>();
            newC.card = remainingDeck[rand];
            newC.LoadCard();
            newC.deck = this;
            newC.mana = myMana;
            if(side == Side.player)
            {
                nc.GetComponent<CardHolder>().side = CardHolder.Side.Player;
            }

            nc.transform.localScale = new Vector3(2, 2, 2);
            remainingDeck.RemoveAt(rand);
        }
    }

    public void Setup()
    {
        for (int i = 0; i < startAmount; i++)
        {
            GetNewCard();
        }
    }

    public void RemoveFromHand(Card cardUsed)
    {
        for (int i = 0; i < inHand.Count; i++)
        {
            if(cardUsed == inHand[i])
            {
                inHand.RemoveAt(i);
                break;
            }
        }
        usedThisGame.Add(cardUsed);
    }

    public void RemoveEnemyHand()
    {

    }
}
