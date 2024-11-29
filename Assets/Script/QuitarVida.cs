using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarVida : MonoBehaviour
{
    public VidaJugador vidaJugador;
    public bool PuedeDañar = true;
    private float Cooldown = 0.01f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && PuedeDañar)
        {
            vidaJugador.RecibirDaño(1);
            PuedeDañar = false;
            StartCoroutine(CooldownDaño());
        }
    }

    IEnumerator CooldownDaño()
    {
        yield return new WaitForSeconds(Cooldown);
        PuedeDañar = true;
    }
}
