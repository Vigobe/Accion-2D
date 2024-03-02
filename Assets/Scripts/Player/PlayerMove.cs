    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float velocidad = 10f;

    private Rigidbody2D rigidbody2D;
    private PlayerAcciones acciones;
    private Vector2 direccionMovimiento;


    private void Awake()
    {
        acciones  = new PlayerAcciones();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        CapturarInput();
    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MoverPlayer()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direccionMovimiento * (velocidad * Time.fixedDeltaTime));
    }
    private void CapturarInput()
    {
        direccionMovimiento = acciones.Movimiento.Mover.ReadValue<Vector2>().normalized;
    }
    private void OnEnable()
    {
        acciones.Enable();
    }

    private void OnDisable()
    {
        acciones.Disable();
    }
}
