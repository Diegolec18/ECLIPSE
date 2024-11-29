using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform puntoInicio; // Punto de inicio al que se teletransportará el jugador

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mover al jugador al punto de inicio
            Transform jugador = GameObject.FindWithTag("Player").transform;
            if (jugador != null)
            {
                jugador.position = puntoInicio.position;
                jugador.rotation = puntoInicio.rotation; // Opcional: restablecer la rotación
            }
        }
    }

    
}
