using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeckCard : MonoBehaviour {
    MainDeck mDeck;

    public GameObject fightButton;
    public GameObject deckButton;

    // Use this for initialization
    void Start () {
        mDeck = GameObject.FindGameObjectWithTag("MainDeck").GetComponent<MainDeck>();

        fightButton = GameObject.FindGameObjectWithTag("FightButton");
        deckButton = GameObject.FindGameObjectWithTag("DeckButton");

        fightButton.SetActive(false);
        deckButton.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = Instantiate(mDeck.deck[Random.Range(0, mDeck.deck.Count)].gameObject, transform.position, Quaternion.identity);
            fightButton.SetActive(true);
            deckButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
