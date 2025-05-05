using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public float speed = 10f;
    public float distanciaActivacion = 5f; // Máxima distancia para activarse
    public static bool activado = false;

    private Transform jugador; // Referencia al jugador

    void Start()
    {
        // Busca al jugador por tag (asegúrate de que tenga el tag "Player")
        GameObject jugadorGO = GameObject.FindGameObjectWithTag("Player");
        if (jugadorGO != null)
        {
            jugador = jugadorGO.transform;
        }
    }

    void Update()
    {
        if (!activado || jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            Vector3 aceleracion = Input.acceleration;
            Vector3 movimiento = new Vector3(aceleracion.x, 0f, aceleracion.y);
            transform.Translate(movimiento * speed * Time.deltaTime);
        }
    }
}
