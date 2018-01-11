using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectionCard : MonoBehaviour {
    public Image mySprite;
    //private Card thisCard;
    public DeckBuilding deckEditor;
    private GameObject myPanel;

    private GameObject previewCard;
    private Vector3 startScale;

    public bool inCollection;

    
	// Use this for initialization
	void Start () {
        //If scene = collection scene of iets dergelijks
        //thisCard = GetComponent<Card>();

   
            mySprite = GetComponent<Image>();
            deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
            myPanel = GameObject.FindGameObjectWithTag("CollectionPanel");

            previewCard = gameObject;
            startScale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void Click()
    {
        
        if (!GetComponent<DeckCard>().inDeck)
        {
            if (deckEditor.isEditing)
            {
                deckEditor.AddToDeck(gameObject);
                //if (deckEditor.playerDeck.Count < deckEditor.maxDeckSize)
                //{
                //    GameObject w = Instantiate(gameObject);
                //    deckEditor.playerDeck.Add(w.GetComponent<DeckBuilderCardHolder>().card);
                   
                //    w.GetComponent<DeckCard>().myIndex = deckEditor.playerDeck.IndexOf(w.GetComponent<DeckBuilderCardHolder>().card);
                //    deckEditor.ShowDeckCards(w);

                //}

                
            }
            else if (Input.GetMouseButtonDown(1) && deckEditor.currentlyPreviewing != previewCard)
            {
                Destroy(deckEditor.currentlyPreviewing);

                previewCard = Instantiate(gameObject, deckEditor.zoompos.GetComponent<RectTransform>().position, Quaternion.identity) as GameObject;

                previewCard.GetComponent<CollectionCard>().enabled = false;
                previewCard.GetComponent<Image>().raycastTarget = false;
                previewCard.transform.SetParent(myPanel.transform, false);
                previewCard.GetComponent<Image>().SetNativeSize();
                previewCard.GetComponent<RectTransform>().localScale = new Vector3(.8F, .8F, 1F);
                previewCard.transform.GetComponent<RectTransform>().position = deckEditor.zoompos.GetComponent<RectTransform>().position;


                deckEditor.currentlyPreviewing = previewCard;
            }
            else if (Input.GetMouseButtonDown(1) && deckEditor.currentlyPreviewing == previewCard)
            {
                previewCard = gameObject;
                Destroy(deckEditor.currentlyPreviewing);
                deckEditor.currentlyPreviewing = null;
            }




        }
    }

    public void HoverEnter()
    {
        if (!GetComponent<DeckCard>().inDeck)
        {
            transform.localScale = new Vector3(1.55F, 1.55F, 1F);
            
        }
            
    }

    public void HoverExit()
    {
        if (!GetComponent<DeckCard>().inDeck)
        {
            transform.localScale = startScale;
        }
          
    }
          
}
