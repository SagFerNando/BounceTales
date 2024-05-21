using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    public float jumpForce = 5f;
    public float bounceDamping = 0.8f;
    public float velocidad = 2f; // Velocidad de movimiento de la esfera
    private float posicionFijaZ = 52.26f; // La posición fija en el eje Z

    private Rigidbody rb;
    private bool isGrounded;
    private ParticleSystem jumpParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpParticles = GetComponentInChildren<ParticleSystem>();

        if (jumpParticles == null)
        {
            Debug.LogError("No se encontró un sistema de partículas como hijo de la esfera.");
        }
    }

    void Update()
    {
        // Obtener la entrada del jugador en el eje horizontal
        float movimiento = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        // Aplicar el movimiento en el eje X, manteniendo la posición fija en Z
        transform.Translate(movimiento, 0, 0);

        // Mantener la posición fija en Z
        Vector3 posicionActual = transform.position;
        posicionActual.z = posicionFijaZ;
        transform.position = posicionActual;

        // Mantener la rotación fija en (0, 0, 0)
        transform.rotation = Quaternion.identity;

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Activar partículas de salto
            if (jumpParticles != null)
            {
                jumpParticles.Play();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la esfera está en el suelo
        if (collision.contacts[0].point.y <= transform.position.y)
        {
            isGrounded = true;
        }

        // Efecto de rebote
        if (!isGrounded && collision.relativeVelocity.y > 0.1f)
        {
            Vector3 bounce = collision.relativeVelocity * -bounceDamping;
            rb.velocity = new Vector3(rb.velocity.x, bounce.y, rb.velocity.z);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si la esfera no está en contacto con el suelo
        isGrounded = false;
    }
}
