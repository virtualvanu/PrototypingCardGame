﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour
{

    public Card card;

    [Header("Card UI Setup")]
    public Image iconImage;
    [Space(10)]
    public Transform manaCrystalHolder;
    public GameObject manaCrystal;
    [Space(10)]
    public Transform attributeHolder;
    public List<GameObject> attributes = new List<GameObject>();

    // all you gotta do to use a card is call: card.Use(); and voila
    // base Use(); could contain a generic animation for using the card or find the enemy it has to attack (EnemyManager, enemies will also be scriptableobjects)

    private void Awake()
    {
        for (int i = 0; i < card.manaCost; i++)
        {
            Instantiate(manaCrystal, manaCrystalHolder.position, Quaternion.identity, manaCrystalHolder);
        }

        //iconImage.sprite = card.icon;
    }

    private void Start()
    {
        card.Setup(this);
    }

    public void CreateAttribute(int attribute, int value)
    {
        GameObject newAttribute = Instantiate(attributes[attribute], attributeHolder.position, Quaternion.identity, attributeHolder);
        newAttribute.transform.GetChild(1).GetComponent<Text>().text = value.ToString();
    }
}
