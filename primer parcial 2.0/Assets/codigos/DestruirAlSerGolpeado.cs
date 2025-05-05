using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlSerGolpeado : MonoBehaviour
{
    public string tagDeLaBola = "Bola"; // Cambia según el tag real de la bola

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDeLaBola))
        {
            Destroy(gameObject);
        }
    }
}
