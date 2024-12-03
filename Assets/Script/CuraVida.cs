using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurarVidaItem : MonoBehaviour
{
    public int cantidadCura = 1; // Cantidad de vida que restaurará este ítem

    // Se llama cuando algo entra en el collider del objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona tiene el script VidaJugador
        VidaJugador vidaJugador = other.GetComponent<VidaJugador>();

        if (vidaJugador != null)
        {
            vidaJugador.ObtenerVida(cantidadCura); // Cura al jugador
            Destroy(gameObject); // Destruye el ítem después de usarlo
        }
    }
}
