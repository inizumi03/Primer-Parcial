using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform objetivo; // El personaje a seguir
    public Vector3 offset = new Vector3(0f, 5f, -8f); // Distancia desde el personaje
    public float suavizado = 5f; // Qu� tan suave sigue la c�mara

    private Vector3 posicionDeseada;

    void LateUpdate()
    {
        if (objetivo == null) return;

        // Calcula la posici�n deseada (fija rotaci�n)
        posicionDeseada = objetivo.position + offset;

        // Movimiento suave hacia esa posici�n
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
    }
}
