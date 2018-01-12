using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    public static IntroManager instance;

    public static bool hasCharacter;

    public GameObject titlePanel;

    public GameObject characterCreationPanel;
    public Transform classButtons;

    public float buttonLerpDelay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayButton()
    {
        if (hasCharacter)
        {
            // Go to level select scene
        }
        else
        {
            // Pick a character to play
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

    public void ConfirmCharacterButton()
    {
        GameManager.instance.opponents.Remove(GameManager.instance.player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DeselectAllCharacters()
    {
        for (int i = 0; i < classButtons.transform.childCount; i++)
        {
            classButtons.transform.GetChild(i).GetComponent<ClassButton>().selectedOverlay.SetActive(false);
        }
    }
}
