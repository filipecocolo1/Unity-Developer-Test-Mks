using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D RB;
    public float _pSpeed;
  
    private Vector2 _pDirection;
    public Animator _animator;

    public Transform _gunTip;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _pDirection.x = (Input.GetAxisRaw("Horizontal"));
        _pDirection.y = (Input.GetAxisRaw("Vertical"));

       
        _animator.SetFloat("Horizontal", _pDirection.x );


        _animator.SetFloat("Vertical", _pDirection.y);
        _animator.SetFloat("Velocidade",_pDirection.sqrMagnitude);
     
    }

    void FixedUpdate()
    {
        RB.MovePosition(RB.position +_pDirection *_pSpeed *Time.fixedDeltaTime);

 
    }
}
