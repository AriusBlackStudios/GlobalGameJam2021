using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //changed health to a float to be able to 
    //change strength (and,inturn,damage, a percentage boost)

    int Pebbles, Razorblades, Cigbutts;
    float PlayerSpeed,PlayerStrength, PlayerHealth, PlayerDamage;

    bool HSA,isAlive,bleeding;//herpisyphilaids

    //will be set to active when player gets a new weapon or HSA,
    //will be deactivated on click
    public GameObject TutorialPanel;

    public Text notification,Tutorial;
    Slider HealthBar;


    void Start()
    {
        //load in File if applicable??? nah???
        HealthBar.value = HealthBar.maxValue;
      
    }

    // Update is called once per frame
    void Update()
    {
        //gamestate only works if player is alive
        if (isAlive)
        {
            HealthBar.value = PlayerHealth;
            Controls();
            //deal bleeding damage if applicable
            if (bleeding)
            {
                //after ten real life seconds turn off???
                PlayerTakeDamage(4);
            }
            //half max health for a time
            if (HSA)
            {
                HealthBar.maxValue = HealthBar.maxValue / 2;
                //slowly increase maxhealth up to its real max, somehow?
            }
            //check for upgrade, made a strength variable to upgrade all weapons at once
            if (Cigbutts% 10==0)
            {
                PlayerStrength += 5;
                ChangeDamage();

            }
        }
        else if (!isAlive)
        {
            //playdeath animation
            //open fail scene
        }
    }

    //gotta set up ketboard controls
    //would like to check for controller connection
    void Controls()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //check tag of object to see if its a puddle
        if()
        {
            HSA = true;
        }

        //check for enemy Tag
        else if ()
        {
            PlayerTakeDamage(3);
            //check for roach spit
            if ()
            {
                Speed = Speed / 2;
            }
            //check for claws
            else if ()
            {
                bleeding = true;
                //reset bleeding timer?
            }
        }

    }

    //called from enemy script and on trigger enter to deal damage or modify the player health;
    void PlayerTakeDamage(float attack)
    {
        PlayerHealth = PlayerHealth - attack;
    }
    //called to check for upgrade in player update
    void ChangeDamage()
    {
        if (PlayerStrength % 5 == 0)
        {
            PlayerDamage = PlayerDamage * 1.01f;
        }
        //ten percent increase in damage
    }
}
