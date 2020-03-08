using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float Speed = 20;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            transform.forward * Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collisionObject)
    {
        if(collisionObject.tag == "Inimigo")
        {
            Destroy(collisionObject.gameObject);
        }

        Destroy(gameObject);
    }
}
