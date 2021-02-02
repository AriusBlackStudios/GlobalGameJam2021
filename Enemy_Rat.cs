using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rat : Enemy
{
    public float health, damage, speed, distPassPlayer;
    private Vector3 left, right;
    public bool LeftRight;
    public Player player;

    void Start()
    {
        health = 50;
        damage = 15;
        speed = 2;
        distPassPlayer = 10;
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        //Dies if it has no health
        if(health < 0)
        {
            Destroy(this.gameObject);
        }
        Move();
    }

    protected override void Attack()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().PlayerTakeDamage(damage);
        }
    }

    protected override void Move()
    {
        left.Set(-1f, 0f, 0f);
        right.Set(1f, 0f, 0f);
        
        //distPassPlayer is how far the enemy moves before going back.
        if (player.transform.position.x - distPassPlayer > transform.position.x)
        {
            //the rat looks at it's relitive position compared to the area it chaces the player and if it walks out of the area it turns arround
            this.GetComponent<SpriteRenderer>().flipX = false;
            LeftRight = false;
        }
        else if (player.transform.position.x + distPassPlayer < transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            LeftRight = true;
        }

        //Changes direction if the rat runs out of the bounds
        if (LeftRight)
        {
            transform.Translate(left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(right * speed * Time.deltaTime);
        }
    }

    public override void TakeDamage(float DamageTaken)
    {
        health -= DamageTaken;
    }
}
