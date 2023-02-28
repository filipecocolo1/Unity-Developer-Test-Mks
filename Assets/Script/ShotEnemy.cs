using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
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
    void OnBecameInvisible()
    {

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
