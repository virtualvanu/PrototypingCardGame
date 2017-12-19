using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDeck : MonoBehaviour {
    public List<Card> remainingDeck = new List<Card>();
    public List<Card> inHand = new List<Card>();
    public GameObject cardPrefab;

    public int startAmount;

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
            nc.transform.SetParent(gameObject.transform);
            nc.GetComponent<CardHolder>().card = remainingDeck[rand];
            nc.GetComponent<CardHolder>().LoadCard();
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
}
