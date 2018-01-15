using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Card))]
public class CustomCardInterface : Editor
{

    Card card;

    private void OnEnable()
    {
        card = (Card)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("General Variables", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
            GUILayout.Label("Card Name: ");
            card.cardName = EditorGUILayout.TextField(card.cardName, GUILayout.Width(180));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.Label("Card Mana Cost: ");
            card.manaCost = EditorGUILayout.IntField(card.manaCost, GUILayout.Width(180));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
            GUILayout.Label("Card Icon: ");
            card.icon = (Sprite)EditorGUILayout.ObjectField(card.icon, typeof(Sprite), allowSceneObjects: true);
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.Space(20);

        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Card Categories:", EditorStyles.boldLabel);
            if (GUILayout.Button("+", GUILayout.Width(20)))
            {
                AddCategory();
            }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.categories.Count; i++)
        {
            GUILayout.BeginHorizontal();
            card.categories[i] = (Card.Category)EditorGUILayout.EnumPopup("Category: ", card.categories[i]);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveCategory(i);
                return;
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.EndVertical();

        GUILayout.Space(20);

        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Card Functionality:", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        #region Damage Addons
        GUILayout.BeginHorizontal("box");
            GUILayout.Label("Total Damage Addons: " + card.damageAddons.Count);
            if (GUILayout.Button("+", GUILayout.Width(20)))
            {
                AddDamageAddon();
            }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.damageAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Damage Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveDamageAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.damageAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.damageAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.damageAddons[i].damage = EditorGUILayout.IntField("Damage: ", card.damageAddons[i].damage);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region Heal Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total Heal Addons: " + card.healAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddHealAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.healAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Heal Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveHealAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.healAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.healAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.healAddons[i].healAmount = EditorGUILayout.IntField("Heal Amount: ", card.healAddons[i].healAmount);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region DOT Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total DOT Addons: " + card.dotAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddDOTAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.dotAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("DOT Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveDOTAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.dotAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.dotAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.dotAddons[i].damage = EditorGUILayout.IntField("Damage: ", card.dotAddons[i].damage);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.dotAddons[i].duration = EditorGUILayout.IntField("Duration: ", card.dotAddons[i].duration);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region HOT Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total HOT Addons: " + card.hotAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddHOTAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.hotAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("HOT Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveHOTAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.hotAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.hotAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.hotAddons[i].healAmount = EditorGUILayout.IntField("Heal Amount: ", card.hotAddons[i].healAmount);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.hotAddons[i].duration = EditorGUILayout.IntField("Duration: ", card.hotAddons[i].duration);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region SpellPower Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total Spell Power Addons: " + card.spellPowerAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddSpellPowerAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.spellPowerAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Spell Power Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveSpellPowerAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.spellPowerAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.spellPowerAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.spellPowerAddons[i].spellPower = EditorGUILayout.IntField("Spell Power: ", card.spellPowerAddons[i].spellPower);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region Draw Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total Draw Addons: " + card.drawAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddDrawAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.drawAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Draw Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveDrawAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.drawAddons[i].target = (CardAddon.Target)EditorGUILayout.EnumPopup("Target: ", card.drawAddons[i].target);

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            card.drawAddons[i].amountToDraw = EditorGUILayout.IntField("Amount To Draw: ", card.drawAddons[i].amountToDraw);

            GUILayout.EndHorizontal();

            GUILayout.Space(20);
        }
        #endregion

        #region Steal Card Addons
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Total Steal Card Addons: " + card.stealCardAddons.Count);
        if (GUILayout.Button("+", GUILayout.Width(20)))
        {
            AddStealCardAddon();
        }

        GUILayout.EndHorizontal();

        for (int i = 0; i < card.stealCardAddons.Count; i++)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Steal Card Addon", EditorStyles.boldLabel);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                RemoveStealCardAddon(i);
                return;
            }

            GUILayout.EndHorizontal();

            GUILayout.Label("The Steal Card Addon can only be used by the \nplayer to steal a card from the AI opponent.");
        }
        #endregion

    }

    #region Adding/Removing Addons
    private void AddDamageAddon()
    {
        card.damageAddons.Add(new CardAddon_Damage());
    }
    private void RemoveDamageAddon(int i)
    {
        card.damageAddons.RemoveAt(i);
    }

    private void AddHealAddon()
    {
        card.healAddons.Add(new CardAddon_Heal());
    }
    private void RemoveHealAddon(int i)
    {
        card.healAddons.RemoveAt(i);
    }

    private void AddDOTAddon()
    {
        card.dotAddons.Add(new CardAddon_DOT());
    }
    private void RemoveDOTAddon(int i)
    {
        card.dotAddons.RemoveAt(i);
    }

    private void AddHOTAddon()
    {
        card.hotAddons.Add(new CardAddon_HOT());
    }
    private void RemoveHOTAddon(int i)
    {
        card.hotAddons.RemoveAt(i);
    }

    private void AddSpellPowerAddon()
    {
        card.spellPowerAddons.Add(new CardAddon_SpellPower());
    }
    private void RemoveSpellPowerAddon(int i)
    {
        card.spellPowerAddons.RemoveAt(i);
    }

    private void AddDrawAddon()
    {
        card.drawAddons.Add(new CardAddon_Draw());
    }
    private void RemoveDrawAddon(int i)
    {
        card.drawAddons.RemoveAt(i);
    }

    private void AddStealCardAddon()
    {
        card.stealCardAddons.Add(new CardAddon_StealCard());
    }
    private void RemoveStealCardAddon(int i)
    {
        card.stealCardAddons.RemoveAt(i);
    }
    #endregion

    private void AddCategory()
    {
        card.categories.Add(new Card.Category());
    }
    private void RemoveCategory(int i)
    {
        card.categories.RemoveAt(i);
    }
}
