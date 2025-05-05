using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirProyectil : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo antes de destruirse automáticamente
    public string tagEnemigo = "Enemigo"; // Tag del enemigo

    void Start()
    {
        // Destruir después de cierto tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagEnemigo))
        {
            // Aquí también puedes agregar efectos, daño, etc.
            Destroy(gameObject);
        }
    }
}
