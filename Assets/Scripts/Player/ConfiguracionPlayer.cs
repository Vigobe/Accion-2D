using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConfiguracionPlayer : ScriptableObject
{
    [Header("Datos")]
    public int Nivel;
    public string Nombre;
    public Sprite Icono;

    [Header("Valores")]
    public float SaludActual;
    public float SaludMaxima;
    public float Armadura;
    public float ArmaduraMaxima;
    public float Energia;
    public float EnergiaMaxima;
    public float ChanceCritico;
    public float DañoCritico;

   
}
