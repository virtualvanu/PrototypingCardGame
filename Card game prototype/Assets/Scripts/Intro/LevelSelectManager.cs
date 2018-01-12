using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public static LevelSelectManager instance;

    public List<ClassButton> levelButtons = new List<ClassButton>();
    public float buttonLerpDelay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(ReadyLevelButtons());
    }

    private IEnumerator ReadyLevelButtons()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelButtons[i].pickableCharacter = GameManager.instance.opponents[i];

            if (levelButtons[i].pickableCharacter.defeated)
            {
                levelButtons[i].defeatedOverlay.SetActive(true);
            }

            levelButtons[i].gameObject.SetActive(true);
            levelButtons[i].canLerp = true;

            yield return new WaitForSeconds(buttonLerpDelay);
        }
    }

    public void LoadDeckBuildSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
