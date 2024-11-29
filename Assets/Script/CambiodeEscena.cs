using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiodeEscena : MonoBehaviour
{
    // Cambia de escena usando el nombre
    public void CambiarEscenaPorNombre(string Nivel1)
    {
        SceneManager.LoadScene(Nivel1);
    }
}
