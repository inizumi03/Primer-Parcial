using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAutomatico : MonoBehaviour
{
    public GameObject prefabDisparo;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 500f;
    public float intervaloDisparo = 1f; // Tiempo entre disparos (en segundos)

    private float temporizador = 0f;

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= intervaloDisparo)
        {
            Disparar();
            temporizador = 0f;
        }
    }

    void Disparar()
    {
        if (prefabDisparo != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(prefabDisparo, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(puntoDisparo.forward * fuerzaDisparo);
            }
        }
    }
}
