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

    public GameObject testParticle;
    public Transform testRayOrigin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Test();
        }
    }

    private void Test()
    {
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.transform.forward);
        Vector3 rayEnd = ray.origin + (ray.direction * 10);

        print(rayEnd);
        testParticle.transform.position = rayEnd;
    }

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
