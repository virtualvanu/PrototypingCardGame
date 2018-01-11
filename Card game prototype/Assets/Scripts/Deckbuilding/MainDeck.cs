using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainDeck : MonoBehaviour {
    private GameObject canvas;

    public List<GameObject> deck = new List<GameObject>();
    public GameObject cardBackPrefab;
    private GameObject tempObject;
    private bool isDrawingCard;
    public bool cardOnTable;
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("UIM");
	}
	
	// Update is called once per frame
	void Update () {
        if (isDrawingCard)
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 0;
            tempObject.transform.position = Camera.main.ScreenToWorldPoint(mPos - tempObject.transform.position);
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(tempObject);
                tempObject = null;
                isDrawingCard = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                tempObject.transform.position = new Vector3(tempObject.transform.position.x, tempObject.transform.position.y, 0);
                cardOnTable = true;
                isDrawingCard = false;
            }
        }
    }

    public void DrawCard()
    {
        Debug.Log("Start draw");
        if (!isDrawingCard && !cardOnTable)
        {
            tempObject = Instantiate(cardBackPrefab, Vector2.zero, Quaternion.identity);
            
            isDrawingCard = true;
        }
       
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
