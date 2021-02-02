using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cat : Enemy
{
    public float health, damage, attackInterval, timeBetweenAttack;
    public Vector3 pos, rotate;
    private Quaternion toRotate;
    public GameObject Hairball,HairballSP;
    public Player player;
    void Start()
    {
        health = 150;
        damage = 30;
        attackInterval = 2;
        timeBetweenAttack = 0;
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        timeBetweenAttack += Time.deltaTime;
        if (attackInterval < timeBetweenAttack)
        {
            Attack();
            timeBetweenAttack = 0;
        }
        if (health < 0)
        {
            player.Pebbles = +100;
            player.CigCounter.text = "" + player.Cigbutts;
            Destroy(this.gameObject,0.5f);
            Application.Quit();
        }
    }
    protected override void Attack()
    {
        AudioSource meow=GetComponent<AudioSource>();
        meow.Play();
        HairballSP.transform.LookAt(player.transform);
        GameObject hairBall = Instantiate(Hairball, HairballSP.transform);
        Destroy(hairBall, 1f);
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float Damagetaken)
    {
        Debug.Log("damage");
        health = health - Damagetaken;
    }

}
