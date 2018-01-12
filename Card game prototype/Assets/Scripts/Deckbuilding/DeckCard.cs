using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour {
    public DeckBuilding deckEditor;
    public bool inDeck;
    public int myIndex;
    public GameObject mySceneObject;
    public GameObject myCollectionObject;
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
            //if (Input.GetMouseButtonDown(0))
            //{
                deckEditor.playerDeck.Remove(GetComponent<DeckBuilderCardHolder>().card);
                deckEditor.instantiatedCards--;
                myCollectionObject.GetComponent<CollectionCard>().amountInCollection++;
                if (!mySceneObject.GetComponent<CollectionCard>().inCollection)
                {
                    Destroy(mySceneObject);
                }
             
                Destroy(gameObject);
            //}
        }
    }
}
