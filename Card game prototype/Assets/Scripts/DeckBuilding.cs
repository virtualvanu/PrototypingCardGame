using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckBuilding : MonoBehaviour {
    public List<GameObject> playerDeck = new List<GameObject>();
    //public List<GameObject> previewDeck = new List<GameObject>();
    public int maxDeckSize;

    public GameObject zoompos;
    public int instantiatedCards;
    private GameObject deckContent;
    private GameObject canvas;
    public bool isEditing;
    public GameObject currentlyPreviewing;
	// Use this for initialization
	void Start () {
        deckContent = GameObject.FindGameObjectWithTag("DeckContent");
        canvas = GameObject.FindGameObjectWithTag("ColCanvas");
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
}
