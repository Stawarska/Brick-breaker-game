using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void StartGame(){
        SceneManager.LoadScene("Brick breaker v1.1");
    }

    public void ScoreBoard(){
        SceneManager.LoadScene("Score Board");
    }

    public void Settings(){
        SceneManager.LoadScene("Settings");
    }

}
