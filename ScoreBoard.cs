using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI highscoreAndName;


   public void StartGame(){
        SceneManager.LoadScene("Brick breaker v1.1");
    }

      public void Quit(){
        SceneManager.LoadScene("Start Menu");
    }

    void Start(){
        highscoreAndName.text = PlayerPrefs.GetString("HIGHSCORENAME") + "   -   " + PlayerPrefs.GetInt("HIGHSCORE") + " points";
    }
}
