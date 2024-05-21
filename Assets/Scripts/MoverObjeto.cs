using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public enum DireccionMovimiento
    {
        ArribaAbajo,
        IzquierdaDerecha
    }

    public DireccionMovimiento direccion = DireccionMovimiento.ArribaAbajo;
    public float distancia = 10f;
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private Vector3 puntoA;
    private Vector3 puntoB;
    private bool yendoAPuntoB = true;

    void Start()
    {
        posicionInicial = transform.position;

        // Definir los puntos A y B basados en la dirección del movimiento
        if (direccion == DireccionMovimiento.ArribaAbajo)
        {
            puntoA = posicionInicial;
            puntoB = new Vector3(posicionInicial.x, posicionInicial.y + distancia, posicionInicial.z);
        }
        else if (direccion == DireccionMovimiento.IzquierdaDerecha)
        {
            puntoA = posicionInicial;
            puntoB = new Vector3(posicionInicial.x + distancia, posicionInicial.y, posicionInicial.z);
        }
    }

    void Update()
    {
        // Mover el objeto entre los puntos A y B
        if (yendoAPuntoB)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoB, velocidad * Time.deltaTime);
            if (transform.position == puntoB)
            {
                yendoAPuntoB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
            if (transform.position == puntoA)
            {
                yendoAPuntoB = true;
            }
        }
    }
}
