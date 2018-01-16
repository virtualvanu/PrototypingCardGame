using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour
{

    public DeckBuilding deckEditor;
    public bool inDeck;
    public int myIndex;
    public GameObject mySceneObject;
    public GameObject myCollectionObject;

    void Start ()
    {
        deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
    }

    public void Click()
    {
        if (inDeck)
        {
            deckEditor.playerDeck.Remove(GetComponent<DeckBuilderCardHolder>().card);
            deckEditor.instantiatedCards--;
            myCollectionObject.GetComponent<CollectionCard>().amountInCollection++;
            deckEditor.SetAmountText();
            if (!mySceneObject.GetComponent<CollectionCard>().inCollection)
            {
                Destroy(mySceneObject);
            }
             
            Destroy(gameObject);
        }
    }
}
