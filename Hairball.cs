using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairball : MonoBehaviour
{
    public float speed;
    private Vector3 forward;
   // Player player;
    public float damage;
    private void Start()
    {
     //  player = FindObjectOfType<Player>();
    }



    void Update()
    {
        forward.Set(1f, 0f, 0f);

        transform.Translate(forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().PlayerTakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
