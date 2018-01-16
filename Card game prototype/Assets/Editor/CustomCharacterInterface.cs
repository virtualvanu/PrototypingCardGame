using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CustomCharacterInterface : Editor
{

    Character character;

    private void OnEnable()
    {
        character = (Character)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("General Variables", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Has this character been defeated?");
        character.defeated = EditorGUILayout.Toggle(character.defeated, GUILayout.Width(20));
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Character Name: ");
        character.characterName = EditorGUILayout.TextField(character.characterName, GUILayout.Width(180));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Character Avatar: ");
        character.avatar = (Sprite)EditorGUILayout.ObjectField(character.avatar, typeof(Sprite), allowSceneObjects: true);
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.Space(20);

        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Stats:", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Max Health: ");
        character.maxHealth = EditorGUILayout.IntField(character.maxHealth, GUILayout.Width(180));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Current Health: ");
        character.currentHealth = EditorGUILayout.IntField(character.currentHealth, GUILayout.Width(100));
        if (GUILayout.Button("Fill", GUILayout.Width(75)))
        {
            FillCurrentHealth();
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Shield Amount: ");
        character.shieldHealth = EditorGUILayout.IntField(character.shieldHealth, GUILayout.Width(180));
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.Space(20);

        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Deck:", EditorStyles.boldLabel);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddCard();
            return;
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Total: " + character.deck.Count);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        for (int i = 0; i < character.deck.Count; i++)
        {
            GUILayout.BeginHorizontal();

            character.deck[i] = (Card)EditorGUILayout.ObjectField(character.deck[i], typeof(Card));
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveCard(i);
                return;
            }

            GUILayout.EndHorizontal();
        }

        GUILayout.EndVertical();

    }

    private void FillCurrentHealth()
    {
        character.currentHealth = character.maxHealth;
    }

    private void RemoveCard(int i)
    {
        character.deck.RemoveAt(i);
    }

    private void AddCard()
    {
        character.deck.Add(new Card());
    }
}
