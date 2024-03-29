using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSalud : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ConfiguracionPlayer configPlayer;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecibirDaņo(1.0f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RecuperarSalud(1.0f);
        }
    }
    public void RecuperarSalud(float cantidad)
    {
        configPlayer.SaludActual += cantidad;
        if (configPlayer.SaludActual > configPlayer.SaludMaxima)
        {
            configPlayer.SaludActual = configPlayer.SaludMaxima;
        }
    }
    
    public void RecibirDaņo(float cantidad)
    {
        if (configPlayer.Armadura > 0)
        {
            float daņoRestante = cantidad - configPlayer.Armadura;
            configPlayer.Armadura = Mathf.Max(configPlayer.Armadura - cantidad, 0f);

            if (daņoRestante > 0)
            {
                configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - daņoRestante, 0f);

            }
        }
        else
        {
            configPlayer.SaludActual = Mathf.Max(configPlayer.SaludActual - cantidad, 0f);
        }

        if (configPlayer.SaludActual <= 0f)
        {
            PlayerDerrotado();
        }         
    }
    private void PlayerDerrotado()
    {
        Destroy(gameObject);
        Debug.Log("DErrotado");
    }
}
