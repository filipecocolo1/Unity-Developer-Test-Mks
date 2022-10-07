using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    public float e_Speed;
    public float e_WaitingTime;
    public Transform[] e_Position;

    int e_Randomic;
    float e_Time;



    // Start is called before the first frame update
    void Start()
    {
        e_Randomic = Random.Range(0, e_Position.Length);
        e_Time = e_WaitingTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, e_Position[e_Randomic].position, e_Speed * Time.deltaTime);
        float _dist = Vector2.Distance(transform.position, e_Position[e_Randomic].position);

        if (_dist<=.2f)
        {
            if (e_Time<=0)
            {
                e_Randomic = Random.Range(0, e_Position.Length);
                e_Time = e_WaitingTime;
            }
            else
            {
                e_Time -= Time.deltaTime;
            }

        }
    }
}
