using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    

    private float rotationAngle = 0;
    [SerializeField] private float rotationSpeed = 2;
    [SerializeField] private float moveSpeed;
    [SerializeField][Range(0,1)] private float  driftFactor = 1;
    [SerializeField] private float dragFactor = 3;
    [SerializeField] private float maxSpeed = 5;   



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Vertical");
        movement.y = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        ApplySpeed();
        ApplyRotation();
        ApplyDrift();


    }
    void ApplySpeed()
    {
        if (movement.x == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, dragFactor, Time.fixedDeltaTime);

        }
        else
        {
            rb.drag = 0;
        }
        float velocityUp = Vector2.Dot(transform.up, rb.velocity);
        if (velocityUp > maxSpeed) return;
        if (velocityUp < (-maxSpeed * 0.5)) return;
        {

        }

        
        
        rb.AddForce(transform.up * movement.x * moveSpeed, ForceMode2D.Force);


    }
    void ApplyRotation()
    {

        rotationAngle = rotationAngle - (movement.y * rotationSpeed);
        rb.MoveRotation(rotationAngle);



    }
    void ApplyDrift() {
        Vector2 velocityUp = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 velocityRight = transform.right * Vector2.Dot(rb.velocity, transform.right);
            rb.velocity = velocityUp + velocityRight * driftFactor;





    }

}
