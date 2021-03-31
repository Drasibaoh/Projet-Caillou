using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public Text collextibles;
    public Text stateTexte;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject controlsUI;
    public GameObject tutoUI;

    public Image feedbakcImage;
    public List<Sprite> formFeedback;
    void Start()
    {
        stateTexte.text = "Rock";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        collextibles.text =""+GameManager._instance.collectedCollectibles;

        if (PlayerManager._instance.rockState == RockStates.Rock && gameIsPaused == false)
        {
            stateTexte.text = "Rock";
        }
        if (PlayerManager._instance.rockState == RockStates.Fire && gameIsPaused == false)
        {
            stateTexte.text = "Fire";
        }
        if (PlayerManager._instance.rockState == RockStates.Grass && gameIsPaused == false)
        {
            stateTexte.text = "Grass";
        }
        if (PlayerManager._instance.rockState == RockStates.Ice && gameIsPaused == false)
        {
            stateTexte.text = "Ice";
        }
    }

    public void Controls()
    {
        if (controlsUI.activeSelf)
        {
            controlsUI.SetActive(false);
        }
        else
        {
            controlsUI.SetActive(true);
        }
    }
    public void Tuto()
    {
        if (tutoUI.activeSelf)
        {
            tutoUI.SetActive(false);
        }
        else
        {
            tutoUI.SetActive(true);
        }
    }
    public void Resume ()
    {
        gameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause ()
    {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        gameIsPaused = true;
    }

    public void RestartLvL()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
    public void ChangeToRock()
    {
        feedbakcImage.sprite = formFeedback[0];
    }
    public void ChangeToFire()
    {
        feedbakcImage.sprite = formFeedback[1];
    }
    public void ChangeToGrass()
    {
        feedbakcImage.sprite = formFeedback[2];
    }
    public void ChangeToIce()
    {
        feedbakcImage.sprite = formFeedback[3];
    }
}
