using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VidaJugador : MonoBehaviour
{
    public int vidas = 9; // Contador de vidas del jugador
    private Vector3 posicionInicial; // Posición inicial de la pelota
    private Vector3 posicionCheckpoint; // Posición del último checkpoint
    private bool juegoTerminado = false; // Indicador de fin del juego
    public TextMeshProUGUI textoVidas;

    void Start()
    {
        // Guardar la posición inicial de la pelota
        posicionInicial = transform.position;
        // Inicializar la posición del checkpoint con la posición inicial
        posicionCheckpoint = posicionInicial;

        // Inicializar el contador de vidas en los logs
        Debug.Log("Vidas iniciales: " + vidas);
     
         // Asignar el componente TextMeshProUGUI manualmente si no está asignado desde el Inspector
        if (textoVidas == null)
        {
            textoVidas = GameObject.Find("TextoVidas").GetComponent<TextMeshProUGUI>();
        }

        // Inicializar el texto de las vidas
        ActualizarTextoVidas();
    }

    void Update()
    {
        // Verificar si la posición y de la pelota es menor a -4 y si el juego no ha terminado
        if (transform.position.y < -4 && !juegoTerminado)
        {
            // Disminuir el contador de vidas
            vidas--;
            Debug.Log("Vidas restantes: " + vidas);
            ActualizarTextoVidas();

            // Verificar si las vidas llegaron a 0 y manejar la lógica de fin de juego si es necesario
            if (vidas <= 0)
            {
                FinDelJuego();
            }
            else
            {
                // Regresar la pelota a la posición del último checkpoint
                transform.position = posicionCheckpoint;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con un objeto que tiene la etiqueta "obstaculo" y si el juego no ha terminado
        if (collision.gameObject.CompareTag("Obstaculo") && !juegoTerminado)
        {
            // Disminuir el contador de vidas
            vidas--;
            Debug.Log("Vidas restantes: " + vidas);
            ActualizarTextoVidas();

            // Verificar si las vidas llegaron a 0 y manejar la lógica de fin de juego si es necesario
            if (vidas <= 0)
            {
                FinDelJuego();
            }else{
                transform.position = posicionCheckpoint;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el trigger es con un objeto que tiene la etiqueta "checkpoint"
        if (other.gameObject.CompareTag("checkpoint"))
        {
            // Actualizar la posición del checkpoint
            posicionCheckpoint = other.transform.position;
            Debug.Log("Checkpoint actualizado a la posición: " + posicionCheckpoint);
        }
    }

    void FinDelJuego()
    {
        juegoTerminado = true;
        Debug.Log("Fin del juego");
        // Desactivar el componente de movimiento de la esfera si existe
        var movimiento = GetComponent<Moviment>();
        if (movimiento != null)
        {
            movimiento.enabled = false;
        }
        // Otras acciones de fin del juego, como mostrar un mensaje en la UI

        // Detener la ejecución en el Editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Opcional: salir del juego en una build
        Application.Quit();
#endif
    }
    void ActualizarTextoVidas()
    {
        // Actualizar el texto de las vidas en la UI
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }
}
