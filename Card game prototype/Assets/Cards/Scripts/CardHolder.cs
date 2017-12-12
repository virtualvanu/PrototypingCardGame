using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{

    public Card card;

    // all you gotta do to use a card is call: card.Use(); and voila
    // base Use(); could contain a generic animation for using the card or find the enemy it has to attack (EnemyManager, enemies will also be scriptableobjects)
}
