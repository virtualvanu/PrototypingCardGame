using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckBuilding : MonoBehaviour {
    public List<GameObject> playerDeck = new List<GameObject>();
    private int instantiatedCards;
    private GameObject deckContent;
    public bool isEditing;
	// Use this for initialization
	void Start () {
        deckContent = GameObject.FindGameObjectWithTag("DeckContent");
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

    public void ShowDeckCards()
    {
        foreach(GameObject g in playerDeck)
        {
            if(instantiatedCards < playerDeck.Count)
            {
                GameObject q = Instantiate(g, Vector3.zero, Quaternion.identity);
                q.transform.SetParent(deckContent.transform);
                q.GetComponent<RectTransform>().SetAsFirstSibling();
                instantiatedCards++;
            }
        }
    }
}
