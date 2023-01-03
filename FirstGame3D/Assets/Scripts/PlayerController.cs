using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variabili per il movimento del personaggio
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        // Recupero il componente CharacterController del personaggio
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Controllo se il personaggio è a terra
        if (controller.isGrounded)
        {
            // Recupero l'input delle direzioni sull'asse X e Z
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Calcolo la direzione del movimento
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Controllo se viene premuto il tasto per saltare
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Aggiungo la forza di gravità al movimento del personaggio
        moveDirection.y -= gravity * Time.deltaTime;

        // Muovo il personaggio
        controller.Move(moveDirection * Time.deltaTime);
    }
}