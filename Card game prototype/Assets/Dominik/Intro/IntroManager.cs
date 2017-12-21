using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public static bool hasCharacter;

    public GameObject titlePanel;

    public GameObject characterCreationPanel;
    public Transform classButtons;

    public float buttonLerpDelay;

    public void PlayButton()
    {
        if (hasCharacter)
        {
            // continue to level select scene
        }
        else
        {
            // create a character
            titlePanel.SetActive(false);
            characterCreationPanel.SetActive(true);
            StartCoroutine(ReadyClassButtons());
        }
    }

    public IEnumerator ReadyClassButtons()
    {
        foreach (Transform child in classButtons)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<ClassButton>().canLerp = true;

            yield return new WaitForSeconds(buttonLerpDelay);
        }
    }
}
