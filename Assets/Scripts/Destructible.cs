using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructible : MonoBehaviour
{

    public GameObject playerModel;
    public GameObject playerExplosion;
    public float waitTime = 3;
    public string youLose;
    public AudioSource soundSource;
    public AudioClip explosionSound;
    

    public void Destroy()
    {
        Destroy(this.gameObject);
        soundSource.PlayOneShot(explosionSound);
    }

    public void PlayerDestroy()
    {
        Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
        Destroy(playerModel);
        soundSource.PlayOneShot(explosionSound);
        StartCoroutine(Wait(waitTime));
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration); //Wait
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(youLose);
    }
}
