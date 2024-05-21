using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensajePorTag : MonoBehaviour
{
    public TextMeshProUGUI textComent;
    public float duracionMensaje = 2f; // Duración en segundos que el mensaje será visible

    void OnTriggerEnter(Collider other)
    {
        // Obtener la etiqueta del objeto con el que colisiona
        string tagDelObjeto = other.gameObject.tag;

        // Verificar la etiqueta y mostrar el mensaje correspondiente
        switch (tagDelObjeto)
        {
            case "Caida":
                MostrarMensaje("Oh no! Bounce ha caido desde donde esta su casa... por suerte solo tiene que volver a subir...");
                break;
            // Agrega más casos según sea necesario
            case "Tutorial1":
                MostrarMensaje("Pulsa Adelante y Atras para moverse \nPulsa Space para saltar\nPuedes saltar en diferentes direcciones");
                break;
            case "Tutorial2":
                MostrarMensaje("Oh no! El camino parece estar bloqueado, debe haber alguna palanca cerca...");
                break;
            case "Tutorial3":
                MostrarMensaje("Al fin las escaleras a mi casa pero... no puedo derribar esa puerta, si tan solo fuese mas fuerte...");
                break;
            case "StoneBall":
                MostrarMensaje("Hola! Mi nombre es Bumpy, Una ball de roca, mas fuerte y pesada que nadie. Y necesito tu ayuda...");
                break;
            case "Coins":
                MostrarMensaje("Has tocado una moneda.");
                break;
            default:
                // MostrarMensaje("Has tocado un objeto sin etiqueta específica.");
                break;
        }
    }

    void MostrarMensaje(string mensaje)
    {
        StopAllCoroutines(); // Detiene cualquier coroutine en ejecución para mostrar mensajes anteriores
        StartCoroutine(MostrarMensajeTemporalmente(mensaje));
    }

    IEnumerator MostrarMensajeTemporalmente(string mensaje)
    {
        textComent.text = mensaje;
        textComent.gameObject.SetActive(true);

        yield return new WaitForSeconds(duracionMensaje);

        textComent.gameObject.SetActive(false);
    }
}
