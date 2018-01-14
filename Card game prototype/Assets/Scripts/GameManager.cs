using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    [Header("Characters")]
    public Character player;
    public Character opponent;
    [Space(10)]
    public List<Character> opponents = new List<Character>();
    public List<Character> defeatedOpponents = new List<Character>();

    public List<Card> collection = new List<Card>();
    public List<Card> playerDeckEditorDeck = new List<Card>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void AddCardToGamemanagerCollection(Card c)
    {
        GameManager.instance.collection.Add(c);
    }
   

}
