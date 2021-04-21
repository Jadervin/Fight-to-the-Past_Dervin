using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    
    public PlayerControllerAnimated player;
    public Slider healthbar;

    private int healthDisplayed = 0;


    //public KeyCollect collect;
    //public PlayerScript keyCollectConnect;

    // Start is called before the first frame update
    private void Start()
    {

        //KeyDisplay.text = KeyCollect.Instance.currentkeyAmount.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (healthDisplayed != player.HP)
        {
            healthDisplayed = player.HP;
            DisplayHealth();

        }

        
    }

    void DisplayHealth()
    {
        //Transform[] spawnedCrosses = healthParent.GetComponentsInChildren<Transform>();

    }
}
