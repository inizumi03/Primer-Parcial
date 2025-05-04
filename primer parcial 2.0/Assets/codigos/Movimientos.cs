using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 direccionMovimiento;

    // Variables de UI
    public bool moverArriba;
    public bool moverAbajo;
    public bool moverIzquierda;
    public bool moverDerecha;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento con teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movimiento con botones UI (móvil)
        if (moverIzquierda) horizontal = -1;
        if (moverDerecha) horizontal = 1;
        if (moverArriba) vertical = 1;
        if (moverAbajo) vertical = -1;

        direccionMovimiento = new Vector3(horizontal, 0, vertical).normalized;

        animator.SetBool("Caminando", direccionMovimiento.magnitude > 0.1f);
    }

    void FixedUpdate()
    {
        if (direccionMovimiento.magnitude >= 0.1f)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMovimiento);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotacionObjetivo, 0.1f));

            Vector3 movimiento = direccionMovimiento * velocidad;
            rb.MovePosition(rb.position + movimiento * Time.fixedDeltaTime);
        }
    }

    // Estos métodos serán conectados a los botones UI
    public void PresionarArriba() => moverArriba = true;
    public void SoltarArriba() => moverArriba = false;
    public void PresionarAbajo() => moverAbajo = true;
    public void SoltarAbajo() => moverAbajo = false;
    public void PresionarIzquierda() => moverIzquierda = true;
    public void SoltarIzquierda() => moverIzquierda = false;
    public void PresionarDerecha() => moverDerecha = true;
    public void SoltarDerecha() => moverDerecha = false;
}
