using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //The key needed to press and open pause menu
    public string keyName;
    //Game Object in canvas with menu
    public GameObject menuObject;
    
    //public PointandClick pointScript;

    //keeps track of whether game is paused
    bool isPaused = false;
    [Header("Music")]
    public MusicManager musicManager;

    [Header("SFX")]
    //audio source to play UI sound
    public AudioSource soundSource;

    //sounds that will play when 
    public AudioClip pauseSound;
    public AudioClip unpauseSound;
    
    private void Update()
    {
        if (Input.GetButtonDown(keyName))
        {
       

            if(isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();

            }

        }
    }


    public void UnPause()
    {
        menuObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        soundSource.PlayOneShot(unpauseSound);

        //pointScript.enabled = true;
        musicManager.UnPause();
    }

    public void Pause()
    {
        menuObject.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        soundSource.PlayOneShot(pauseSound);

        //pointScript.enabled = false;
        musicManager.Pause();
    }
}
