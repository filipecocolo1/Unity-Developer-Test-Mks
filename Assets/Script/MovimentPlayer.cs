using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D RB;
    public float _pSpeed;
    private Vector2 _pDirection;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _pDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        RB.MovePosition(RB.position +_pDirection *_pSpeed *Time.fixedDeltaTime);

    }
}
