using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGiroscopio : MonoBehaviour
{
    public Button botonGiroscopio;       // Asigna el bot�n desde el inspector
    public Text textoBoton;              // Asigna el Text del bot�n (ni�o del bot�n)

    void Start()
    {
        ActualizarTexto();
        if (botonGiroscopio != null)
        {
            botonGiroscopio.onClick.AddListener(ToggleGiroscopio);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleGiroscopio();
        }
    }

    public void ToggleGiroscopio()
    {
        Gyroscope.activado = !Gyroscope.activado;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (textoBoton != null)
        {
            textoBoton.text = Gyroscope.activado ? "Desactivar" : "Activar";
        }
    }
}
