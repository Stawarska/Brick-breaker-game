using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Brick breaker v1.1");
    }


    public void Quit(){
        SceneManager.LoadScene("Start Menu");
    }
}
