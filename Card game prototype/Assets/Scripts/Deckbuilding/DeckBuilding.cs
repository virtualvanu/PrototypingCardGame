using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckBuilding : MonoBehaviour {
    public List<Card> playerDeck = new List<Card>();
    public List<GameObject> collection = new List<GameObject>();
    //public List<GameObject> previewDeck = new List<GameObject>();
    public int maxDeckSize;

    public GameObject zoompos;
    public int instantiatedCards;
    private GameObject deckContent;
    private GameObject collectionContent;
    private GameObject canvas;
    public bool isEditing;
    public GameObject currentlyPreviewing;

    public GameObject deckBuilderCardHolderPrefab;

    public Character test;
	// Use this for initialization
	void Start () {
        deckContent = GameObject.FindGameObjectWithTag("DeckContent");
        collectionContent = GameObject.FindGameObjectWithTag("ColContent");
        canvas = GameObject.FindGameObjectWithTag("ColCanvas");

        //SetStartDeck(test.deck);
        AddMultipleCardsToCollection(test.deck);

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void StartEditing()
    {
        if (!isEditing)
        {
            isEditing = true;
        }
        else if (isEditing)
        {
            isEditing = false;
        }
    }

    public void ShowDeckCards(GameObject g)
    {
        
            if(instantiatedCards < playerDeck.Count)
            {
                GameObject q = g;

                q.transform.SetParent(deckContent.transform, false);
                //q.GetComponent<Image>().SetNativeSize();
                q.GetComponent<RectTransform>().localScale = new Vector3(.405F, .405F, 1F);
                q.transform.localPosition = deckContent.transform.position;
                //q = Instantiate(q, deckContent.transform.position, Quaternion.identity) as GameObject;
                q.GetComponent<CollectionCard>().enabled = false;
                q.GetComponent<DeckCard>().enabled = true;
                q.GetComponent<DeckCard>().inDeck = true;
                
                //q.GetComponent<Image>().raycastTarget = false;
               
                //previewDeck.Add(q);
                
                instantiatedCards++;
            }

           
       
    }

    public void SetStartDeck(List<Card> c)
    {
        foreach (Card card in c)
        {
            GameObject prefab = Instantiate(deckBuilderCardHolderPrefab);
            prefab.GetComponent<DeckBuilderCardHolder>().card = card;
            prefab.GetComponent<DeckBuilderCardHolder>().LoadCard(); 
            AddToDeck(prefab);
        }
      
    }

    public void AddToDeck(GameObject toAdd)
    {
        if (playerDeck.Count < maxDeckSize)
        {
            GameObject w = Instantiate(toAdd);
            playerDeck.Add(w.GetComponent<DeckBuilderCardHolder>().card);

            w.GetComponent<DeckCard>().myIndex = playerDeck.IndexOf(w.GetComponent<DeckBuilderCardHolder>().card);
            w.GetComponent<DeckCard>().mySceneObject = toAdd;
            ShowDeckCards(w);
        }
     
    }

    public void AddCardToCollection(Card cardToAdd)
    {
        GameObject q = Instantiate(deckBuilderCardHolderPrefab, collectionContent.transform.position, Quaternion.identity);
        DeckBuilderCardHolder d = deckBuilderCardHolderPrefab.GetComponent<DeckBuilderCardHolder>();

        d.card = cardToAdd;
        collection.Add(q);
        

        q.transform.SetParent(collectionContent.transform, false);
        
        q.GetComponent<RectTransform>().localScale = new Vector3(.5F, .5F, 1F);
        q.transform.localPosition = collectionContent.transform.position;
  
        q.GetComponent<CollectionCard>().enabled = true;
        q.GetComponent<DeckCard>().enabled = false;
       
    }

    public void AddMultipleCardsToCollection(List<Card> cardToAdd)
    {
        foreach (Card c in cardToAdd)
        {
            GameObject q = Instantiate(deckBuilderCardHolderPrefab, collectionContent.transform.position, Quaternion.identity);
            DeckBuilderCardHolder d = q.GetComponent<DeckBuilderCardHolder>();

            d.card = c;
            d.LoadCard();
            collection.Add(q);
            


            q.transform.SetParent(collectionContent.transform, false);

            q.GetComponent<RectTransform>().localScale = new Vector3(.5F, .5F, 1F);
            q.transform.localPosition = collectionContent.transform.position;

            q.GetComponent<CollectionCard>().enabled = true;
            q.GetComponent<CollectionCard>().inCollection = true;
            q.GetComponent<DeckCard>().enabled = false;

            
        }
       

    }
}
