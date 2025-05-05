using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public float speed = 10f;
    public float distanciaActivacion = 5f;
    public static bool activado = false;

    private Transform jugador;

    void Start()
    {
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

            // Decidir qué dirección usar (priorizar eje dominante)
            float absX = Mathf.Abs(aceleracion.x);
            float absY = Mathf.Abs(aceleracion.y);

            Vector3 movimiento;

            if (absX > absY)
            {
                movimiento = new Vector3(aceleracion.x, 0f, 0f); // Solo eje X
            }
            else
            {
                movimiento = new Vector3(0f, 0f, aceleracion.y); // Solo eje Z
            }

            transform.Translate(movimiento * speed * Time.deltaTime);
        }
    }
}
