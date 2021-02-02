using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wasp : Enemy
{
    public float health, damage, speedHorizontal, speedVertical, distPassPlayer, maxHight, minHight;
    private Vector3 left, right, up, down;
    public bool LeftRight, UpDown;
    public Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        health = 50;
        damage = 10;
        speedHorizontal = 10;
        speedVertical = 10;
        distPassPlayer = 5;
        maxHight = 25;
        minHight = -3;

    }

    void Update()
    {
        Move();
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected override void Attack()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().PlayerTakeDamage(damage);
        }
    }
    protected override void Move()
    {
        left.Set(-1f, 0f, 0f);
        right.Set(1f, 0f, 0f);
        up.Set(0f, 1f, 0f);
        down.Set(0f, -1f, 0f);
        //distPassPlayer is how far the enemy moves before going back.
        if (player.transform.position.x - distPassPlayer >= transform.position.x)
        {
            //the rat looks at it's relitive position compared to the area it chases the player and if it walks out of the area it turns arround.
            LeftRight = false;
        }
        else if (player.transform.position.x + distPassPlayer <= transform.position.x)
        {
            LeftRight = true;
        }

        //Changes direction if the rat runs out of the bounds
        if (LeftRight)
        {
            transform.Translate(left * speedHorizontal * Time.deltaTime);
            
        }
        else
        {
            transform.Translate(right * speedHorizontal * Time.deltaTime);
        }

        if (transform.position.y >= player.transform.position.y + maxHight)
        {
            UpDown = false;
        }
        else if (transform.position.y <= player.transform.position.y + minHight)
        {
            UpDown = true;
        }

        if (UpDown)
        {
            transform.Translate(up * speedVertical * Time.deltaTime);
        }
        else
        {
            transform.Translate(down * speedVertical * Time.deltaTime);
        }
    }

    public override void TakeDamage(float Damagetaken)
    {
        health -= Damagetaken;
    }
}
