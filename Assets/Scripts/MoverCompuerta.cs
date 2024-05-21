using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCompuerta : MonoBehaviour
{
    public GameObject compuerta; // Referencia al objeto compuerta
    public float distanciaMovimiento = 5f; // Distancia que se moverá la compuerta en el eje Y
    private bool haSidoActivada = false; // Para asegurar que solo se mueva una vez

    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión es con un objeto que tiene la etiqueta "palanca" y que no ha sido activada antes
        if (other.CompareTag("ball") && gameObject.CompareTag("palanca") && !haSidoActivada)
        {
            // Mover la compuerta en el eje Y
            Debug.Log("Colisión con la palanca detectada");
            Vector3 nuevaPosicion = compuerta.transform.position;
            nuevaPosicion.y += distanciaMovimiento;
            compuerta.transform.position = nuevaPosicion;

            // Marcar como activada para que no se repita
            haSidoActivada = true;
        }
    }
}



