using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public GameObject exploseEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);

    }
    void OnBecameInvisible()
    {

        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Barricade")
        {
            Instantiate(exploseEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(exploseEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
