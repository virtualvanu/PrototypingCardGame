using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject
{

    public string characterName;

    [Header("Stats")]
    public int maxHealth;
    [HideInInspector] public int currentHealth;

    [Header("Properties")]
    public List<Card> deck;
}
