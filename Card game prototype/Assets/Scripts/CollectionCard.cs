using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectionCard : MonoBehaviour {
    public Image mySprite;
    //private Card thisCard;
    public DeckBuilding deckEditor;
	// Use this for initialization
	void Start () {
        //If scene = collection scene of iets dergelijks
        //thisCard = GetComponent<Card>();
        mySprite = GetComponent<Image>();
        deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        if (Input.GetMouseButtonDown(0) && deckEditor.isEditing)
        {
            deckEditor.playerDeck.Add(gameObject);
            deckEditor.ShowDeckCards(gameObject);
        }
       
    }
}
