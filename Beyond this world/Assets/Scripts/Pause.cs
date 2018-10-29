using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    private bool paused = false;
    public GameObject pauseMenu;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
	}

    public void PauseResume()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseMenu.SetActive(paused);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(paused);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
