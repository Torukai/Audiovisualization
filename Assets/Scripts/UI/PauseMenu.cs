using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject presetsMenu;
    public GameObject optionsMenu;
    public GameObject songsMenu;
    public GameObject kochLines;
    public GameObject kochTrails;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (IsPaused)
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
        pauseMenuUI.SetActive(false);
        presetsMenu.SetActive(false);
        songsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        kochLines.SetActive(true);
        kochTrails.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = false;
	}

    void Pause()
	{
        pauseMenuUI.SetActive(true);
        kochLines.SetActive(false);
        kochTrails.SetActive(false);
        Time.timeScale = 0.04f;
        IsPaused = true;
	}

    public void Songs()
	{
        pauseMenuUI.SetActive(false);
        songsMenu.SetActive(true);
    }

    public void Presets()
    {
        pauseMenuUI.SetActive(false);
        presetsMenu.SetActive(true);
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        presetsMenu.SetActive(false);
        songsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Quit()
	{
        Application.Quit();
	}
}
