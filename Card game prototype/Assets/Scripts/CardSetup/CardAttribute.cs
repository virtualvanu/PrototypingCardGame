using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardAttribute : MonoBehaviour
{

    public enum Type
    {
        Damage,
        Heal,
        DOT,
        HOT,
        DamageIncrease
    }
    public Type type;
    [Space(10)]

    public Image icon1;
    public TextMeshProUGUI text1;
    [Space(10)]
    public Image icon2;
    public TextMeshProUGUI text2;


    public void Setup(Sprite i1, string t1)
    {
        icon1.sprite = i1;
        text1.text = t1;

        icon2.enabled = false;
        text2.enabled = false;
    }

    public void Setup(Sprite i1, string t1, Sprite i2, string t2)
    {
        icon1.sprite = i1;
        text1.text = t1;
        icon2.sprite = i2;
        text2.text = t2;
    }
}
