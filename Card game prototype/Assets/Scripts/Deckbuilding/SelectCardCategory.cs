using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCardCategory : MonoBehaviour
{

    public string categoryButtonName;
    public List<Card.Category> categories = new List<Card.Category>();

    private void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = categoryButtonName;
    }
}
