using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float Speed = 10;
    public bool Life = true;
    public LayerMask FloorMask; 
    public GameObject TextGameOver;
    Vector3 direction;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direction = new Vector3(eixoX, 0, eixoZ);

        if (direction != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if(Life == false)
        {
            if (Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position +
            (direction * Speed * Time.deltaTime));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100 , Color.red);

        RaycastHit impact;
        if (Physics.Raycast(ray, out impact, 100, FloorMask)) {
            Vector3 playerCrosshair = impact.point - transform.position;
            playerCrosshair.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(playerCrosshair);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
