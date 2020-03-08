using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContralaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direction = Jogador.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if (distance > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direction.normalized * Speed * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Life = false;
    }
}
