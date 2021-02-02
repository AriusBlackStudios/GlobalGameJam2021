using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirtpile : MonoBehaviour
{
    int bug = 0;
    int rat = 0;
    public string DirtID;
    public GameObject Rat,Wasp;
    public float health;
    public Player player;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        health = 100;

    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            if (rat < 1)
            {
                ReleaseRat();
                rat++;
            }
            if (bug < 1)
            {
                ReleaseWasp();
                bug++;
            }  
        }
    }



    void ReleaseRat()
    {
        Instantiate<GameObject>(Rat.gameObject, spawner.transform.position, spawner.transform.rotation);
        
    }
    void ReleaseWasp()
    {
        Instantiate<GameObject>(Wasp.gameObject, spawner.transform.position,spawner.transform.rotation);

    }
    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        Debug.Log("HIt");
    }
}
