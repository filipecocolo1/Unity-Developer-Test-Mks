using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
   [SerializeField] private Transform _gunSight;

   [SerializeField] private GameObject _shoot;
   [SerializeField] private GameObject _specialshoot;

    public int _mountShoot;
    public float _amountTotalShoot = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("apertou espaço");
            Bullet();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            print("apertou J");
            BulletSpecial();
        }
    }

    public void Bullet()
    {

        GameObject bulllet = Instantiate(_shoot, _gunSight.position, _gunSight.rotation);


    }

    public void BulletSpecial()
    {

        GameObject specialshoot = Instantiate(_specialshoot, _gunSight.position, _gunSight.rotation);

    }




}
