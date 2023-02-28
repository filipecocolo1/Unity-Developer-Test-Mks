using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject exploseEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(exploseEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
    




