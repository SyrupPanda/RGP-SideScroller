using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public float damage;

    //void Update()
    //{
    //	transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
    //}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<HealthComponent>() != null)
            {
                other.GetComponent<HealthComponent>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
