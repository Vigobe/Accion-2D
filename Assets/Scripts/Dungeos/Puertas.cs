using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    private readonly int cerrarPuertaAnim = Animator.StringToHash("CerrarPuerta");
    private readonly int abrirPuertaAnim = Animator.StringToHash("AbrirPuerta");
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MostrarAnimacionCerrar()
    {
        animator.SetTrigger(cerrarPuertaAnim);

    }

    public void MostrarAnimacionAbrir()
    {
        animator.SetTrigger(abrirPuertaAnim);
    }
}
