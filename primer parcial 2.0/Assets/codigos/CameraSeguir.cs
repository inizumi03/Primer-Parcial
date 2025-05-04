using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform objetivo; // El personaje a seguir
    public Vector3 offset = new Vector3(0f, 5f, -8f); // Distancia desde el personaje
    public float suavizado = 5f; // Qué tan suave sigue la cámara

    private Vector3 posicionDeseada;

    void LateUpdate()
    {
        if (objetivo == null) return;

        // Calcula la posición deseada (fija rotación)
        posicionDeseada = objetivo.position + offset;

        // Movimiento suave hacia esa posición
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);
    }
}
