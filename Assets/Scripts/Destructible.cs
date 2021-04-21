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

    public void Destroy()
    {
        Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
        Destroy(playerModel);
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene(youLose);
    }
}
