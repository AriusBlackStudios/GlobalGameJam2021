using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected abstract void Attack();
    protected abstract void Move();
    public abstract void TakeDamage(float Damagetaken);
}
