using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject GunBarrel;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, GunBarrel.transform.position, GunBarrel.transform.rotation);
        }
    }
}
