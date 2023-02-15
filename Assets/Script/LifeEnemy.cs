using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    public int _lifeEnemy = 5;


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
        if (col.gameObject.tag == "Shoot")
        {
            _lifeEnemy--;

        }
        if (_lifeEnemy == 0)

        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "ShootSecond")
        {
            _lifeEnemy-=2;

        }
        if (_lifeEnemy <= 0)

        {
            Destroy(gameObject);
        }

    }



}
