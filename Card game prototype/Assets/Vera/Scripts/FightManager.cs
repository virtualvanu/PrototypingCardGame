using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {
    public static FightManager instance;
    public Character player;
    public Character enemy;
    public List<Card> playerDeck;
    public List<Card> enemyDeck;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public static void SetDeck(List<Card> cards)
    {

    }
}
