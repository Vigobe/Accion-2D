using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergia : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ConfiguracionPlayer configPlayer;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GastarEnergia(1.0f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            RecuperarEnergia(1.0f);
        }
    }

    public void GastarEnergia(float cantidad)
    {
        configPlayer.Energia -= cantidad;
        if (configPlayer.Energia < 0f)
        {
            configPlayer.Energia = 0f;

        }

    }

    public void RecuperarEnergia(float cantidad)
    {
        configPlayer.Energia += cantidad;
        if (configPlayer.Energia > configPlayer.EnergiaMaxima)
        {
            configPlayer.Energia = configPlayer.EnergiaMaxima;

        }
    }
}
