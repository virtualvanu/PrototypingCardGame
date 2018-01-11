using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : MonoBehaviour {
    private bool zoomedIn;
    public Vector2 zoomedCardPos;
    private GameObject temp;
	// Use this for initialization
	void Start () {
        zoomedCardPos.x = 7.5F;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!zoomedIn)
            {
                temp = Instantiate(gameObject, zoomedCardPos, Quaternion.identity);
                temp.transform.localScale = new Vector3(0.9F, 0.9F, 1);
                temp.GetComponent<MonsterCard>().enabled = false;
                temp.GetComponent<BoxCollider2D>().enabled = false;
               
                zoomedIn = true;
            }
            else if (zoomedIn)
            {
                Destroy(temp);
                zoomedIn = false;
            }
        }
    }
}
