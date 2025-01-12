
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    public float totalHealth = 100;
    public float playerHealth;
    public Slider playerHealthSlider;
    void Start()
    {
        playerHealth = totalHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            DamagePlayer(25f);
        }
    }
   public void DamagePlayer(float damaged)
        {
        if (playerHealth <= 0)
        {
            playerHealth = 0;


        }
        else if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        else
        {
            playerHealth -= damaged;
           
        }
        playerHealthSlider.value = playerHealth;
    }

       
        }
    

