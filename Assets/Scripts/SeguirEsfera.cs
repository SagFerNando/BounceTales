using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirEsfera : MonoBehaviour
{
    public Transform esfera; // La esfera que la cámara debe seguir
    public Vector3 offset; // Desplazamiento de la cámara respecto a la esfera

    void LateUpdate()
    {
        // Asegurar que la cámara siga a la esfera pero sin rotar con ella
        Vector3 posicionDeseada = esfera.position + offset;
        transform.position = posicionDeseada;

        // Mantener la rotación fija de la cámara
        transform.rotation = Quaternion.identity;
    }
}

