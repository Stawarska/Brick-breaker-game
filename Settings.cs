using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void StartGame(){
        SceneManager.LoadScene("Brick breaker v1.1");
    }


    public void Quit(){
        SceneManager.LoadScene("Start Menu");
    }

    public void BackgroundSetVolume(float volume){
        audioMixer.SetFloat("Background music volume", volume);
    }

     public void SoundsSetVolume(float volume){
        audioMixer.SetFloat("MyExposedParam 1", volume);
    }
}
