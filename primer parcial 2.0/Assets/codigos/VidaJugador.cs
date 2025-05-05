using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VidaJugador : MonoBehaviour

{
    public int vidas = 3;
    public Image[] iconosVida; // Asigna 3 imágenes desde el Canvas
    public GameObject canvasGameOver; // Asigna el canvas de Game Over en el Inspector

    private bool estaMuerto = false;

    void Start()
    {
        ActualizarVidas();
        if (canvasGameOver != null)
            canvasGameOver.SetActive(false);
    }

    public void QuitarVida()
    {
        if (estaMuerto || vidas <= 0) return;

        vidas--;
        ActualizarVidas();

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    void ActualizarVidas()
    {
        for (int i = 0; i < iconosVida.Length; i++)
        {
            iconosVida[i].enabled = i < vidas;
        }
    }

    void GameOver()
    {
        estaMuerto = true;

        if (canvasGameOver != null)
            canvasGameOver.SetActive(true);

        Time.timeScale = 0f; // Pausar el juego
    }

    void Update()
    {
        if (estaMuerto && Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarEscena();
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
