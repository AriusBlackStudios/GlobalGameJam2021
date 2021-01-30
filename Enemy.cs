using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //basics
    float EnemyHealth, EnemyDamage, EnemySpeed;

    //may be implemented by weapons of player if time allows
    bool isPoisoned, isBleeding;

    void TakeDamage(float attack)
    {
        EnemyHealth = EnemyHealth - attack;
    }
    public abstract void Attack();

    public abstract void Move();

    //to be referenced from player script, controls, 
    //attack related to poison. Maybe the syringe?
    public void Poison()
    {
        isPoisoned = true;
        //set a timer? here or in update???
    }
    //to be referenced from player script, controls, 
    //attack related to bleeding?. Maybe the axe?
    public void Bleeding()
    {
        isBleeding = true;
        //set timer
        //here or in update????
    }
}
