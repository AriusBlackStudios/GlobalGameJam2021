using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector3 forward;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward.Set(1f, 0f, 0f);

        transform.Translate(forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
