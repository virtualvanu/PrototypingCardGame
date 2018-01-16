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
    public bool isEditing;
    public GameObject currentlyPreviewing;

    public GameObject deckBuilderCardHolderPrefab;

    public Character test; //DELET DIS(Testing var)
    public TextMeshProUGUI amountLeftText;
    public List<Card> testCards = new List<Card>();

    public static bool savedOnce;
    GameObject[] all;
    // Use this for initialization
    void Start () {
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
	
	// Update is called once per frame
	void Update () {
        Debug.Log(all.Length);
	}

    public void SetAmountText()
    {
        amountLeftText.text = "Cards in deck: " + playerDeck.Count + "/" + maxDeckSize;
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

    public void ChangeTab(int tab)
    {
        if (tab == 0)
        {
            
            
           
            foreach (GameObject c in all)
            {
                //c.transform.Find("GreyedOutPanel").gameObject.SetActive(false);
                c.SetActive(true);
                c.transform.SetParent(collectionContent.transform, false);

                c.GetComponent<RectTransform>().localScale = new Vector3(1F, 1F, 1F);
                c.transform.localPosition = collectionContent.transform.position;
            }

            

        }
        else if (tab == 1)
        {
          

            foreach (GameObject c in all)
            {
                
                    DeckBuilderCardHolder dbh = c.GetComponent<DeckBuilderCardHolder>();
                    if (dbh.card.categories.Contains(Card.Category.Heal) || dbh.card.categories.Contains(Card.Category.HOT))
                    {
                        c.SetActive(true);
                    }
                    else
                    {
                        c.SetActive(false);
                    }

             
            }
        }
        else if (tab == 2)
        {


            foreach (GameObject c in all)
            {
                
                    DeckBuilderCardHolder dbh = c.GetComponent<DeckBuilderCardHolder>();
                    if (dbh.card.categories.Contains(Card.Category.Damage) || dbh.card.categories.Contains(Card.Category.DOT) || dbh.card.categories.Contains(Card.Category.Buffs))
                    {
                        c.SetActive(true);
                    }
                    else
                    {
                        c.SetActive(false);
                    }

    
            }
        }
        else if (tab == 3)
        {
           

            foreach (GameObject c in all)
            {
               
                    DeckBuilderCardHolder dbh = c.GetComponent<DeckBuilderCardHolder>();
                    if (dbh.card.categories.Contains(Card.Category.Other))
                    {
                        c.SetActive(true);
                    }
                    else
                    {
                        c.SetActive(false);
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
        GameManager.instance.player.deck = GameManager.instance.playerDeckEditorDeck;

        savedOnce = true;
    }

    public void SetStart()
    {
       
        AddMultipleCardsToCollection(GameManager.instance.collection);
        SetStartDeck(GameManager.instance.player.deck);

    }
}
