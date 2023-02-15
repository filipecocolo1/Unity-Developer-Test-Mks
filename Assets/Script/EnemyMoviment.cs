using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyMoviment : MonoBehaviour
{

    public float speed;
    float waitTime;
    float startWaitime;

    public Transform point;


    public Transform _pivot;


    public Transform[] moveSPots;
    private int randomSpot;
    

       
    void Start()
    {
        //posição aleatoria onde o barco deve seguir
        randomSpot = Random.Range(0, moveSPots.Length);
        Transform _point = GameObject.Find("Point").transform;

        moveSPots = new Transform[_point.childCount];
        for (int i = 0; i < _point.childCount; i++)
        {
            moveSPots[i] = _point.GetChild(i);
        }

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSPots[randomSpot].position, speed * Time.deltaTime);
        transform.up = (moveSPots[randomSpot].position - transform.position).normalized;
        if (Vector2.Distance(transform.position, moveSPots[randomSpot].position) < 0.2f)
        {
            if (waitTime < 0)
            {
                randomSpot = Random.Range(0, moveSPots.Length);
                waitTime = startWaitime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
