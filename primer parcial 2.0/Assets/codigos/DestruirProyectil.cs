using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirProyectil : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo antes de destruirse autom�ticamente
    public string tagEnemigo = "Enemigo"; // Tag del enemigo

    void Start()
    {
        // Destruir despu�s de cierto tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagEnemigo))
        {
            // Aqu� tambi�n puedes agregar efectos, da�o, etc.
            Destroy(gameObject);
        }
    }
}
