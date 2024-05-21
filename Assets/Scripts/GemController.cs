using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación de la gema

    void Update()
    {
        // Hacer que la gema gire continuamente
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball")) // Asegúrate de que la esfera tenga la etiqueta "Player"
        {
            // Llamar al script del jugador para aumentar el contador de puntos
            PuntosJugador puntosJugador = other.GetComponent<PuntosJugador>();
            if (puntosJugador != null)
            {
                puntosJugador.AumentarPuntos();
            }

            // Desactivar la gema
            gameObject.SetActive(false);
        }
    }
}
