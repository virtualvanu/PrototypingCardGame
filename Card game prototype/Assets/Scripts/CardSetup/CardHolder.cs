using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardHolder : MonoBehaviour
{

    public Card card;
    public CurrentDeck deck;
    public ManaCount mana;

    public enum Side
    {
        Enemy,
        Player
    }
    public Side side;

    private bool canDissolve;

    [Header("Card UI Setup")]
    public TextMeshProUGUI nameText;
    public Image iconImage;
    [Space(10)]
    public Transform manaCrystalHolder;
    public GameObject manaCrystal;
    [Space(10)]
    public Transform attributeHolder;
    public GameObject attributePrefab;
    public List<Sprite> attributeIcons = new List<Sprite>();

    Image[] images;
    List<Image> toDissolve = new List<Image>();

    private void Awake()
    {
        if (!FightManager.inFight)
        {
            LoadCard();
        }
    }

    private void Update()
    {
        if (canDissolve)
        {
            DissolveCard();
        }
    }

    public void LoadCard()
    {
        for (int i = 0; i < card.manaCost; i++)
        {
            Instantiate(manaCrystal, manaCrystalHolder.position, Quaternion.identity, manaCrystalHolder);
        }

        nameText.text = card.cardName;
        //iconImage.sprite = card.icon;

        card.Setup(this);

        images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.material.name == "Card")
            {
                image.material = new Material(image.material);
                toDissolve.Add(image);
            }
        }
    }

    public void CreateAttribute(CardAttribute.Type type, int value1)
    {
        GameObject newAttribute = Instantiate(attributePrefab, attributeHolder.position, Quaternion.identity, attributeHolder);
        CardAttribute attribute = newAttribute.GetComponent<CardAttribute>();

        switch (type)
        {
            case CardAttribute.Type.Damage:

                attribute.Setup(attributeIcons[0], value1.ToString(), FightManager.instance.damageColor);
                break;
            case CardAttribute.Type.Heal:

                attribute.Setup(attributeIcons[1], value1.ToString(), FightManager.instance.healColor);
                break;
            case CardAttribute.Type.DamageIncrease:

                attribute.Setup(attributeIcons[0], value1.ToString(), FightManager.instance.healColor);
                break;
        }
    }

    public void CreateAttribute(CardAttribute.Type type, int value1, int value2)
    {
        GameObject newAttribute = Instantiate(attributePrefab, attributeHolder.position, Quaternion.identity, attributeHolder);
        CardAttribute attribute = newAttribute.GetComponent<CardAttribute>();

        switch (type)
        {
            case CardAttribute.Type.DOT:

                attribute.Setup(attributeIcons[2], value1.ToString(), attributeIcons[3], value2.ToString(), FightManager.instance.damageColor);
                break;
            case CardAttribute.Type.HOT:

                attribute.Setup(attributeIcons[1], value1.ToString(), attributeIcons[3], value2.ToString(), FightManager.instance.healColor);
                break;
            case CardAttribute.Type.DamageIncrease:

                attribute.Setup(attributeIcons[0], value1.ToString(), attributeIcons[3], value2.ToString(), FightManager.instance.healColor);
                break;
        }
    }

    public void DissolveCard()
    {
        canDissolve = true;

        TextMeshProUGUI[] textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textObject in textObjects)
        {
            textObject.gameObject.SetActive(false);
        }

        foreach (Image image in toDissolve)
        {
            image.material.SetFloat("_Threshold", image.material.GetFloat("_Threshold") + (Time.deltaTime * 1.5f));
        }

        if (images[0].material.GetFloat("_Threshold") >= 0.85f)
        {
            Destroy(gameObject);
        }
    }

    public void UseButton()
    {
        if (FightManager.instance.turn == FightManager.Turn.player && side == Side.Player)
        {
            if (mana.CheckMana(card.manaCost) == true)
            {
                deck.RemoveFromHand(card);
                card.Use(this);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Normal");
            }
        }
        else if (FightManager.instance.turn == FightManager.Turn.enemy && side == Side.Enemy)
        {
            if (mana.CheckMana(card.manaCost) == true)
            {
                deck.RemoveFromHand(card);
                card.Use(this);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Normal");
            }
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Normal");
            print("test print voor animation bug");
        }
    }
}
