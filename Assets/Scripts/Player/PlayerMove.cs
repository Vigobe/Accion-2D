using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float velocidadMovimiento = 10f;

    [Header("Dash")]
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempoDash;
    [SerializeField] private float transparencia; 
    
    private Rigidbody2D rb2D;
    private PlayerAcciones acciones;
    private SpriteRenderer spriteRenderer;
    private bool usandoDash;

    private float velocidadActual;
    private Vector2 direccionMovimiento;


    private void Awake()
    {
        acciones  = new PlayerAcciones(); //Herencia clase PlayerAcciones
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();


    }

    private void Start()
    {
        velocidadActual = velocidadMovimiento;
        acciones.Movimiento.Dash.performed += ctx => Dash();
    }

    private void Update()
    {
        CapturarInput();
        RotarPlayer();

    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MoverPlayer()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direccionMovimiento * (velocidadActual * Time.fixedDeltaTime));
    }

    private void Dash()
    {
        if (usandoDash)
        {
            return;
        }
        usandoDash = true;
        StartCoroutine(IEDash());

    }
    private IEnumerator IEDash()
    {
        velocidadActual = velocidadDash;
        ModificarSpriteRenderer(transparencia);
        yield return new WaitForSeconds(tiempoDash);
        ModificarSpriteRenderer(valor: 1f);
        velocidadActual = velocidadMovimiento;
        usandoDash = false;

    }
    private void ModificarSpriteRenderer(float valor) 
    {
        Color color = spriteRenderer.color;
        color = new Color(color.r, color.g,color.b,valor);
        spriteRenderer.color = color;

    }

    private void RotarPlayer()
    {
        if (direccionMovimiento.x >= 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (direccionMovimiento.x < 0f)
        {
            spriteRenderer.flipX = true;
        } 
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
