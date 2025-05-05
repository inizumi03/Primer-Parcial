using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Recolector : MonoBehaviour
{
    public int totalObjetosNecesarios = 3;
    private int cantidadRecolectada = 0;

    public Text textoContador; // Asigna el Text del UI que muestra "Tiene X/3"
    public Canvas canvasFinal; // Si usas Canvas, asígnalo aquí
    public string nombreEscenaASaltar; // Si dejas esto vacío, se usa Canvas en su lugar

    void Start()
    {
        ActualizarTexto();
        if (canvasFinal != null)
            canvasFinal.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recolectable"))
        {
            cantidadRecolectada++;
            other.gameObject.SetActive(false); // Desactiva el objeto
            ActualizarTexto();

            if (cantidadRecolectada >= totalObjetosNecesarios)
            {
                ActivarFinal();
            }
        }
    }

    void ActualizarTexto()
    {
        textoContador.text = $"Tiene {cantidadRecolectada}/{totalObjetosNecesarios}";
    }

    void ActivarFinal()
    {
        if (!string.IsNullOrEmpty(nombreEscenaASaltar))
        {
            SceneManager.LoadScene(nombreEscenaASaltar);
        }
        else if (canvasFinal != null)
        {
            canvasFinal.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Recolectado todo, pero no se definió acción final.");
        }
    }
}
