using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [HideInInspector]public TextMeshProUGUI nameText;

    private void Awake()
    {
        nameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        if (pickableCharacter != null)
        {
            nameText.text = pickableCharacter.characterName;
        }
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

    public void SelectLevel()
    {
        GameManager.instance.opponent = pickableCharacter;
        //SceneManager.LoadScene();
    }
}
