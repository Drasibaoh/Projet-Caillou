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
        collextibles.text = ": " + GameManager._instance.collectedCollectibles;

        if (Input.GetKeyDown(KeyCode.Keypad1) && gameIsPaused == false)
        {
            stateTexte.text = "Rock";
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && gameIsPaused == false)
        {
            stateTexte.text = "Fire";
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && gameIsPaused == false)
        {
            stateTexte.text = "Grass";
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && gameIsPaused == false)
        {
            stateTexte.text = "Ice";
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

}
