using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public string startSceneName;
    public string Menu;
    public string Credits;

    public AudioSource soundSource;
    public AudioClip menu;

    public void StartPressed()
    {
        SceneManager.LoadScene(startSceneName);
      
    
    
    }
    public void MenuPressed()
    {
        soundSource.PlayOneShot(menu);
        SceneManager.LoadScene(Menu);



    }
    public void CreditsPressed()
    {
        SceneManager.LoadScene(Credits);



    }
    public void CloseGame()
    {
        Application.Quit();


    }

    
    
}
