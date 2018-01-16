using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class DeckBuilding : MonoBehaviour {
    public List<Card> playerDeck = new List<Card>();
    public List<Card> collection = new List<Card>();
    //public List<GameObject> previewDeck = new List<GameObject>();
    public int maxDeckSize;

    public GameObject deckScrollview;
    public GameObject zoompos;
    public int instantiatedCards;
    public GameObject deckContent;
    private GameObject collectionContent;
    private GameObject canvas;
    public bool isEditing = true;
    public GameObject currentlyPreviewing;

    public GameObject deckBuilderCardHolderPrefab;

    public Character test; //DELET DIS(Testing var)
    public TextMeshProUGUI amountLeftText;
    public List<Card> testCards = new List<Card>();

    public static bool savedOnce;
    public AllCards allCards;
    GameObject[] all;

    void Start ()
    {
        allCards = GetComponent<AllCards>();
        deckContent = GameObject.FindGameObjectWithTag("DeckContent");
        collectionContent = GameObject.FindGameObjectWithTag("ColContent");
        canvas = GameObject.FindGameObjectWithTag("ColCanvas");
        SetStart();
        all = GameObject.FindGameObjectsWithTag("DeckBuildCard");

        //if (!savedOnce)
        //{
        //    AddMultipleCardsToCollection(GameManager.instance.player.deck);
        //    SetStartDeck(GameManager.instance.player.deck);
        //    RefreshDeckContent();
        //}
        //else
        //{
        //    collection = GameManager.instance.collection;
        //    playerDeck = GameManager.instance.playerDeckEditorDeck;

        //    AddMultipleCardsToCollection(collection);
        //    SetStartDeck(playerDeck);
        //    RefreshDeckContent();






        //}

        //AddMultipleCardsToCollection(GameManager.instance.player.deck);





    }
	
    public void SetAmountText()
    {
        amountLeftText.text = "Cards in deck: " + playerDeck.Count + "/" + maxDeckSize;
    }

    public void ShowDeckCards(GameObject g)
    {
        
            if(instantiatedCards < playerDeck.Count)
            {
                GameObject q = g;
                RuntimeAnimatorController an = q.GetComponent<Animator>().runtimeAnimatorController;
                q.GetComponent<Animator>().runtimeAnimatorController = null;
                q.transform.SetParent(deckContent.transform, false);
                //q.GetComponent<Image>().SetNativeSize();
                q.GetComponent<RectTransform>().localScale = new Vector3(1F, 1F, 1F);
                q.transform.localPosition = deckContent.transform.position;
                //q = Instantiate(q, deckContent.transform.position, Quaternion.identity) as GameObject;
                q.GetComponent<CollectionCard>().enabled = false;
                q.GetComponent<DeckCard>().enabled = true;
                q.GetComponent<DeckCard>().inDeck = true;

            //q.GetComponent<Image>().raycastTarget = false;

            //previewDeck.Add(q);
            q.GetComponent<Animator>().runtimeAnimatorController = an;

            instantiatedCards++;
            }

           
       
    }

    public void SetStartDeck(List<Card> c)
    {
        foreach (Card card in c)
        {
            if (!playerDeck.Contains(card))
            {
                foreach(Card g in collection)
                {
                    if(g == card)
                    {
                        GameObject prefab = Instantiate(deckBuilderCardHolderPrefab);
                        prefab.GetComponent<DeckBuilderCardHolder>().card = card;
                        prefab.GetComponent<DeckBuilderCardHolder>().LoadCard();
                        GameObject[] all = GameObject.FindGameObjectsWithTag("DeckBuildCard");
                        foreach (GameObject k in all)
                        {
                            if(k.GetComponent<DeckBuilderCardHolder>().card == g)
                            {
                                prefab.GetComponent<DeckCard>().myCollectionObject = k;
                            }
                        }
                  
                        AddToDeck(prefab);
                    }
                }

            }
           
        }

        
      
    }

    public void AddToDeck(GameObject toAdd)
    {
        if (playerDeck.Count < maxDeckSize && !playerDeck.Contains(toAdd.GetComponent<DeckBuilderCardHolder>().card))
        {
            GameObject w = Instantiate(toAdd);
            playerDeck.Add(w.GetComponent<DeckBuilderCardHolder>().card);

            w.GetComponent<DeckCard>().myIndex = playerDeck.IndexOf(w.GetComponent<DeckBuilderCardHolder>().card);
            w.GetComponent<DeckCard>().mySceneObject = toAdd;
            foreach(Card g in collection)
            {
                if(g == w.GetComponent<DeckBuilderCardHolder>().card)
                {
                    GameObject[] all = GameObject.FindGameObjectsWithTag("DeckBuildCard");
                    foreach (GameObject k in all)
                    {
                        if (k.GetComponent<DeckBuilderCardHolder>().card == g)
                        {
                            w.GetComponent<DeckCard>().myCollectionObject = k;
                        }
                    }
                   
                }

             
            }

            ShowDeckCards(w);
        }
    }

    public void AddCardToCollection(Card cardToAdd)
    {
        if (!collection.Contains(cardToAdd))
        {
            GameObject q = Instantiate(deckBuilderCardHolderPrefab, collectionContent.transform.position, Quaternion.identity);
            DeckBuilderCardHolder d = q.GetComponent<DeckBuilderCardHolder>();

            d.card = cardToAdd;
            d.LoadCard();

            //q.GetComponent<CollectionCard>().AddOne(); Adds one card of this type to collection

            collection.Add(cardToAdd);
        

            q.transform.SetParent(collectionContent.transform, false);
        
            q.GetComponent<RectTransform>().localScale = new Vector3(1F, 1F, 1F);
            q.transform.localPosition = collectionContent.transform.position;
  
            q.GetComponent<CollectionCard>().enabled = true;
            q.GetComponent<CollectionCard>().inCollection = true;
            q.transform.tag = "DeckBuildCard";
            q.GetComponent<DeckCard>().enabled = false;

        }
       
    }

    public void AddMultipleCardsToCollection(List<Card> cardToAdd)
    {
        foreach (Card c in cardToAdd)
        {
            AddCardToCollection(c);
            //GameObject q = Instantiate(deckBuilderCardHolderPrefab, collectionContent.transform.position, Quaternion.identity);
            //DeckBuilderCardHolder d = q.GetComponent<DeckBuilderCardHolder>();

            //d.card = c;
            //d.LoadCard();
            //collection.Add(q);
            


            //q.transform.SetParent(collectionContent.transform, false);

            //q.GetComponent<RectTransform>().localScale = new Vector3(.5F, .5F, 1F);
            //q.transform.localPosition = collectionContent.transform.position;

            //q.GetComponent<CollectionCard>().enabled = true;
            //q.GetComponent<CollectionCard>().inCollection = true;
            //q.GetComponent<DeckCard>().enabled = false;

            
        }
       

    }

    public void ChangeTab(SelectCardCategory tabButton)
    {
        foreach (GameObject card in all)
        {
            card.SetActive(false);
        }

        foreach (GameObject card in all)
        {
            DeckBuilderCardHolder cardHolder = card.GetComponent<DeckBuilderCardHolder>();

            for (int i = 0; i < tabButton.categories.Count; i++)
            {
                if (cardHolder.card.categories.Contains(tabButton.categories[i]))
                {
                    card.SetActive(true);
                }
            }

        }
       
        RefreshCollectionContent();
    }

    private void RefreshCollectionContent()
    {
        collectionContent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1);
        collectionContent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);
    }

    private void RefreshDeckContent()
    {      
        deckContent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1);
        deckContent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);
        foreach (GameObject c in all)
        {
            if (c.tag != "DeckBuilderCard")
            {
                c.transform.SetParent(deckContent.transform, false);

                c.GetComponent<RectTransform>().localScale = new Vector3(1F, 1F, 1F);
                c.transform.localPosition = deckContent.transform.position;
            }
        }
    }

    public void ExitScene()
    {
        SaveCollectionScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveCollectionScene()
    {
        GameManager.instance.collection = collection;
        GameManager.instance.playerDeckEditorDeck = playerDeck;
        
        savedOnce = true;
    }

    public void SetStart()
    {
        AddMultipleCardsToCollection(allCards.allCards);
        SetStartDeck(GameManager.instance.playerDeckEditorDeck);
    }
}
