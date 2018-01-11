using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeckCard : MonoBehaviour {
    MainDeck mDeck;
    GameManager gm;
	// Use this for initialization
	void Start () {
        mDeck = GameObject.FindGameObjectWithTag("MainDeck").GetComponent<MainDeck>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = Instantiate(mDeck.deck[Random.Range(0, mDeck.deck.Count)].gameObject, transform.position, Quaternion.identity);
            gm.fightButton.SetActive(true);
            gm.deckButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
