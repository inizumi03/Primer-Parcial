using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonaCamaraTrigger : MonoBehaviour
{
    public Camera camaraJugador;
    public Camera camaraAlternativa;
    public GameObject botonUI;

    private bool jugadorEnZona = false;
    private bool camaraAlternativaActiva = false;

    private void Start()
    {
        if (botonUI != null)
            botonUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
            if (botonUI != null)
                botonUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
            if (botonUI != null)
                botonUI.SetActive(false);

            // Si la cámara alternativa estaba activa, volver a la cámara del jugador
            if (camaraAlternativaActiva)
            {
                camaraAlternativa.gameObject.SetActive(false);
                camaraJugador.gameObject.SetActive(true);
                camaraAlternativaActiva = false;
            }
        }
    }

    public void AlternarCamara()
    {
        if (!jugadorEnZona) return;

        camaraAlternativaActiva = !camaraAlternativaActiva;
        camaraJugador.gameObject.SetActive(!camaraAlternativaActiva);
        camaraAlternativa.gameObject.SetActive(camaraAlternativaActiva);
    }
}
