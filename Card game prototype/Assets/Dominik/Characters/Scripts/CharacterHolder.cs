using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{

    public Character character;

    public List<Card> hand;

    public void UseCard()
    {
        if (hand.Count > 0)
        {
            int randomCardFromHand = Random.Range(0, hand.Count);

            hand[randomCardFromHand].Use();
            hand.Remove(hand[randomCardFromHand]);
        }
        else
        {
            // DrawCard(); if theres cards left in his deck or else skip the turn
        }
    }
}
