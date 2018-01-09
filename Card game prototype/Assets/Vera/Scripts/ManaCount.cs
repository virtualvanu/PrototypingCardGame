using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCount : MonoBehaviour {

    public int maxMana;
    public int manaLvl;
    public int currentMana;
    public List<Image> manaCrystals = new List<Image>();
    public List<Image> emptyManaCrystals = new List<Image>();
	void Start () {
        maxMana = manaCrystals.Count;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTurn()
    {
        if(manaLvl + 1 <= maxMana)
        {
            manaLvl++;
        }
        currentMana = manaLvl;
        UpdateCrystals();
        NewEmpty();
    }

    public bool CheckMana(int cost)
    {
        if (currentMana - cost >= 0)
        {
            currentMana -= cost;
            UpdateCrystals();
            return true;
        }
        else return false;
    }

    public void UpdateCrystals()
    {
        for (int i = 0; i < manaCrystals.Count; i++)
        {
            if(i < currentMana)
            {
                manaCrystals[i].enabled = true;
            }
            else
            {
                manaCrystals[i].enabled = false;
            }
        }
    }

    public void NewEmpty()
    {
        for (int i = 0; i < emptyManaCrystals.Count; i++)
        {
            if(i < currentMana)
            {
                emptyManaCrystals[i].enabled = true;
            }
            else
            {
                emptyManaCrystals[i].enabled = false;
            }
        }
    }
}
