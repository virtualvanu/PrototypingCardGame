using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject fightButton;
    public GameObject deckButton;
	// Use this for initialization
	void Start () {
        fightButton = GameObject.FindGameObjectWithTag("FightButton");
        deckButton = GameObject.FindGameObjectWithTag("DeckButton");

        fightButton.SetActive(false);
        deckButton.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
