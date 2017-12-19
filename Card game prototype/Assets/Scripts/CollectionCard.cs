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
	// Use this for initialization
	void Start () {
        //If scene = collection scene of iets dergelijks
        //thisCard = GetComponent<Card>();
        mySprite = GetComponent<Image>();
        deckEditor = GameObject.FindGameObjectWithTag("DE").GetComponent<DeckBuilding>();
        myPanel = GameObject.FindGameObjectWithTag("CollectionPanel");

        previewCard = gameObject;
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
