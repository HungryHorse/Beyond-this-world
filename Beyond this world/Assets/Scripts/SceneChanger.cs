using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToMenu()
    {
        SceneManager.LoadScene(1);
    } 

    public void ChangeToGame()
    {
        SceneManager.LoadScene(0);
    }
}
