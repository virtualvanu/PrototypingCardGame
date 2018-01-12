using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckBuilderCardHolder : CardHolder
{
    public bool awakened;

    private bool canDissolve;

    Image[] images;

    private void Awake()
    {
        if (!awakened)
        {
            awakened = true;
        }
       
    }

    private void Update()
    {
        if (canDissolve)
        {
            DissolveCard();
        }
    }
}
