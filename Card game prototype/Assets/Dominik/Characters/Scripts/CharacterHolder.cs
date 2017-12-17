using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{

    public Character character;

    public List<Card> hand;

    public void DrawCard()
    {
        if (character.deck.Count > 0)
        {
            int randomCardFromDeck = Random.Range(0, character.deck.Count);

            hand.Add(character.deck[randomCardFromDeck]);
            character.deck.Remove(character.deck[randomCardFromDeck]);
        }
        else
        {
            print(character.characterName + " has no cards left in his deck.");
        }
    }

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
