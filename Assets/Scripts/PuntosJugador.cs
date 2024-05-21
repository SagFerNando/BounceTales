using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuntosJugador : MonoBehaviour
{
public int puntos = 0; // Contador de puntos del jugador
public TextMeshProUGUI textPunt;

    public void AumentarPuntos()
    {
        puntos++;
        Debug.Log("Puntos: " + puntos);
        textPunt.text ="Puntos: " + puntos + "/16";
    }
}
