using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaJugador : MonoBehaviour

{
    public int vidas = 3;
    public Image[] iconosVida; // Asigna 3 im�genes desde el Canvas

    void Start()
    {
        ActualizarVidas();
    }

    public void QuitarVida()
    {
        if (vidas <= 0) return;

        vidas--;
        ActualizarVidas();

        if (vidas <= 0)
        {
            Debug.Log("�Game Over!");
            // Aqu� podr�as recargar la escena, mostrar men�, etc.
        }
    }

    void ActualizarVidas()
    {
        for (int i = 0; i < iconosVida.Length; i++)
        {
            iconosVida[i].enabled = i < vidas;
        }
    }
}
