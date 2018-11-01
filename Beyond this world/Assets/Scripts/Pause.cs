using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject[] levers;

    private bool paused = false;
    private Movement playerMove;

    private void Awake()
    {
        Time.timeScale = 1;
        playerMove = player.GetComponent<Movement>();
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
            playerMove.enabled = true;
            for(int i = 0; i < levers.Length; i++)
            {
                levers[i].GetComponent<Lever>().enabled = true;
            }
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(paused);
            playerMove.enabled = false;
            for (int i = 0; i < levers.Length; i++)
            {
                levers[i].GetComponent<Lever>().enabled = false;
            }
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
