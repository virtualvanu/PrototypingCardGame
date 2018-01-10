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
    public List<GameObject> attributes = new List<GameObject>();

    Image[] images;

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
            }
        }
    }

    public void CreateAttribute(int attribute, int value, int duration)
    {
        GameObject newAttribute;

        switch (attribute)
        {
            case 0:

                newAttribute = Instantiate(attributes[attribute], attributeHolder.position, Quaternion.identity, attributeHolder);
                newAttribute.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
                break;
            case 1:

                newAttribute = Instantiate(attributes[attribute], attributeHolder.position, Quaternion.identity, attributeHolder);
                newAttribute.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
                break;
            case 2:

                newAttribute = Instantiate(attributes[attribute], attributeHolder.position, Quaternion.identity, attributeHolder);
                newAttribute.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
                newAttribute.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = duration.ToString();
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

        foreach (Image image in images)
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
        }
    }
}
