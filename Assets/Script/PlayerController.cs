using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform _gunSight;
    public GameObject _shoot;
     public GameObject _specialshoot;

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
    public void Bullet() {

      GameObject bulllet=  Instantiate(_shoot, _gunSight.position, _gunSight.rotation);
    
    
    }
    public void BulletSpecial()
    {

        GameObject specialshoot = Instantiate(_specialshoot, _gunSight.position, _gunSight.rotation);


    }






}
