using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Trash : MonoBehaviour
{
    int randNum = 0;
    Player player;
    System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        //randNum = rand.Next(1, 4);
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        for (int i = 0; i < 3; i++)
        {
            randNum = rand.Next(1, 4);
            if (randNum == 1)
            {
                player.Notification.text = "Clear off the coffee table,You got one Razor!";
                player.Razorblades = player.Razorblades + 1;
                Debug.Log("Razer = " + player.Razorblades);
                player.BladeCounter.text = "" + player.Razorblades;
            }
            else if (randNum == 2)
            {
                player.Notification.text = "You Got Two Cigarette Butts! maybe there's still enough to smoke?";
                player.Cigbutts = player.Cigbutts + 2;
                Debug.Log("cigarette = " + player.Cigbutts);
                player.CigCounter.text = "" + player.Cigbutts;
            }
            else
            {
                player.Notification.text = "You got Three Pebbles! Looks Like You're eating good Tonight!";
                player.Pebbles = player.Pebbles + 3;
                Debug.Log("pebble = " + player.Pebbles);
                player.PebblesCounter.text = "" + player.Pebbles;
            }
        }
        AudioSource shing = GetComponent<AudioSource>();
        shing.Play();
        Destroy(this.gameObject);
    }
}
