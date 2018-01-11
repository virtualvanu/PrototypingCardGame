using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassButton : MonoBehaviour
{

    public Character pickableCharacter;

    [Header("Lerping")]
    public bool canLerp;
    public Transform lerpToTarget;
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Other Stuff")]
    public GameObject selectedOverlay;
    private TextMeshProUGUI nameText;

    private void Awake()
    {
        nameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        nameText.text = pickableCharacter.characterName;
    }

    private void Update()
    {
        if (canLerp)
        {
            Lerp();
        }
    }

    public void Lerp()
    {
        transform.position = Vector3.Lerp(transform.position, lerpToTarget.position, (Time.deltaTime * moveSpeed));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), (Time.deltaTime * rotateSpeed));
    }

    public void SelectCharacter()
    {
        IntroManager.instance.DeselectAllCharacters();
        selectedOverlay.SetActive(true);
        GameManager.instance.player = pickableCharacter;
    }
}
