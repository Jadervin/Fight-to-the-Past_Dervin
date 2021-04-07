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
    public AudioClip menuClick;

    public float clickTimer = 0.5f;

    public void StartPressed()
    {
        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait(clickTimer));
       
      
    
    
    }
    public void MenuPressed()
    {
        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait2(clickTimer));
        



    }
    public void CreditsPressed()
    {

        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait3(clickTimer));
        



    }
    public void CloseGame()
    {

        soundSource.PlayOneShot(menuClick);
        StartCoroutine(Wait4(clickTimer));
        


    }

    IEnumerator Wait(float duration)
    {

        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene(startSceneName);
    }

    IEnumerator Wait2(float duration)
    {

        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene(Menu);
    }


    IEnumerator Wait3(float duration)
    {

        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene(Credits);
    }

    IEnumerator Wait4(float duration)
    {

        yield return new WaitForSeconds(duration);   //Wait
        Application.Quit();
        
    }
}
