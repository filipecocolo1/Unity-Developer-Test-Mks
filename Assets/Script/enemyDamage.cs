using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject exploseEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
