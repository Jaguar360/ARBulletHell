using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseButton;

    public GameObject PauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        pauseButton.SetActive(true);
    }

   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        pauseButton.SetActive(false);
    }

    public void loadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void quitGame()
    {
        Debug.Log("Quitting game...");
    }
}
