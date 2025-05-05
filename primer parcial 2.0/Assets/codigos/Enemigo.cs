using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Vector3 posicionInicial;
    public float fuerzaEmpuje = 500f;

    void Start()
    {
        posicionInicial = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Quitar una vida
            VidaJugador vidaJugador = collision.gameObject.GetComponent<VidaJugador>();
            if (vidaJugador != null)
            {
                vidaJugador.QuitarVida();
            }

            // 2. Empujar al jugador
            Rigidbody rbJugador = collision.gameObject.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                Vector3 direccion = (collision.transform.position - transform.position).normalized;
                rbJugador.AddForce(direccion * fuerzaEmpuje);
            }

            // 3. Resetear posición del enemigo
            transform.position = posicionInicial;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
