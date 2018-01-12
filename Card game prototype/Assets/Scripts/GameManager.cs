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
}
