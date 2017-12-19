using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour {
    public DeckBuilding deckEditor;
    public bool inDeck;
    public int myIndex;
    // Use this for initialization
    void Start () {
        deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        if (inDeck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                deckEditor.playerDeck.Remove(gameObject);
                deckEditor.instantiatedCards--;
                Destroy(gameObject);
            }
        }
    }
}
