using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDeck : MonoBehaviour {

    public List<Card> totalCardDeck = new List<Card>();
    public CurrentDeck currentDeck;

	void Start () {
        currentDeck.remainingDeck = totalCardDeck;
	}
	
	void Update () {
		
	}
}
