using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string Scena;
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisi�n involucra al objeto "Garbage_Truck" y al objeto "Gema"
        if (collision.gameObject.CompareTag("ball") && gameObject.CompareTag("sceneChange"))
        {
            // Carga la escena con el nombre "NombreDeTuOtraEscena" de manera aditiva
            SceneManager.LoadScene(Scena, LoadSceneMode.Single);
        }
    }
}