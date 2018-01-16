using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectionCard : MonoBehaviour
{

    public Image mySprite;
    public DeckBuilding deckEditor;
    private GameObject myPanel;

    private GameObject previewCard;
    private Vector3 startScale;

    public bool inCollection;

    public int amountInCollection;

    public GameObject greyedOutPanel;

	void Start ()
    {
        //If scene = collection scene of iets dergelijks
        //thisCard = GetComponent<Card>();
   
            mySprite = GetComponent<Image>();
            deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
            myPanel = GameObject.FindGameObjectWithTag("CollectionPanel");

            deckEditor.SetAmountText();
            previewCard = gameObject;
            startScale = transform.localScale;

        //amountInCollection = 5;
        //if (!GetComponent<DeckCard>().inDeck && DeckBuilding.savedOnce)
        //{
        //    amountInCollection = 1;
        //}

	}    

    public void Click()
    {
        if (!GetComponent<DeckCard>().inDeck && !deckEditor.playerDeck.Contains(GetComponent<DeckBuilderCardHolder>().card))
        {
            if (deckEditor.isEditing)
            {
                //if(amountInCollection > 0)
                //{
                deckEditor.AddToDeck(gameObject);
                amountInCollection--;
                deckEditor.SetAmountText();

                greyedOutPanel.SetActive(true);
                //}

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

    public void AddOne()
    {
        amountInCollection++;
    }          
}
