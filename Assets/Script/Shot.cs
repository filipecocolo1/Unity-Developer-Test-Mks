using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    private Rigidbody2D rb;
    public GameObject exploseEffect;
    // Start is called before the first frame update
    void Start()
    {
      var  rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       

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
