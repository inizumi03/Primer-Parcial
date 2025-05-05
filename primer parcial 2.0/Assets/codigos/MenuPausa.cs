using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject canvasPausa;
    public string nombreEscenaNueva = "NombreDeLaEscena";

    private bool estaPausado = false;

    void Start()
    {
        if (canvasPausa != null)
            canvasPausa.SetActive(false);
    }

    void Update()
    {
        // Pausar/Reanudar con la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AlternarPausa();
        }
    }

    public void AlternarPausa()
    {
        estaPausado = !estaPausado;

        if (canvasPausa != null)
            canvasPausa.SetActive(estaPausado);

        Time.timeScale = estaPausado ? 0f : 1f;
    }

    public void SalirDelMenu()
    {
        estaPausado = false;
        if (canvasPausa != null)
            canvasPausa.SetActive(false);

        Time.timeScale = 1f;
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void IrAEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaNueva);
    }
}
