using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrosHUD : MonoBehaviour
{
    public Image[] libros; // Arreglo de im�genes de los libros en el HUD
    public Sprite spriteConCandado; // Sprite del libro con candado
    public Sprite spriteNormal; // Sprite del libro normal
    public Canvas canvasVictoria; // Canvas que se activa cuando ganas
    public Canvas canvasHUD; // Canvas del HUD que se desactiva
    public Camera camaraPrincipal; // C�mara principal (actual)
    public Camera camaraSecundaria; // C�mara para la escena de victoria
    public GameObject personajeBailando; // Personaje que baila
    public AudioSource audioFuente; // Fuente de audio para cambiar la m�sica
    public AudioClip nuevaCancion; // Nueva canci�n que se reproducir� al ganar

    private bool[] librosRecogidos; // Estado de cada libro (recogido o no)
    private bool victoriaAlcanzada = false; // Evita que se active m�s de una vez

    void Start()
    {
        // Inicializamos los libros como "no recogidos" y el canvas de victoria desactivado
        librosRecogidos = new bool[libros.Length];
        canvasVictoria.gameObject.SetActive(false);

        // Establecer los sprites iniciales como "con candado"
        for (int i = 0; i < libros.Length; i++)
        {
            libros[i].sprite = spriteConCandado;
        }

        // Aseguramos que la c�mara secundaria y el personaje est�n desactivados al inicio
        if (camaraSecundaria != null)
            camaraSecundaria.enabled = false;

        if (personajeBailando != null)
            personajeBailando.SetActive(false);
    }

    public void RecogerLibro(int indice)
    {
        if (indice >= 0 && indice < librosRecogidos.Length && !librosRecogidos[indice])
        {
            librosRecogidos[indice] = true;

            // Cambiar el sprite del libro al normal
            libros[indice].sprite = spriteNormal;

            // Comprobar si se recogieron todos los libros
            VerificarVictoria();
        }
    }

    private void VerificarVictoria()
    {
        // Si ya se activ� la victoria, no hagas nada
        if (victoriaAlcanzada) return;

        // Verificar si todos los libros han sido recogidos
        foreach (bool recogido in librosRecogidos)
        {
            if (!recogido)
                return; // Si falta alg�n libro, no hacemos nada
        }

        // Marcamos que la victoria fue alcanzada
        victoriaAlcanzada = true;

        // Activar el Canvas de Victoria
        if (canvasVictoria != null)
            canvasVictoria.gameObject.SetActive(true);

        // Desactivar el Canvas del HUD
        if (canvasHUD != null)
            canvasHUD.gameObject.SetActive(false);

        // Cambiar a la c�mara secundaria
        if (camaraPrincipal != null && camaraSecundaria != null)
        {
            
            camaraSecundaria.enabled = true; // Encender la c�mara secundaria
        }

        // Activar el personaje que baila
        if (personajeBailando != null)
            personajeBailando.SetActive(true);

        // Cambiar la m�sica
        if (audioFuente != null && nuevaCancion != null)
        {
            audioFuente.Stop(); // Detener la canci�n actual
            audioFuente.clip = nuevaCancion; // Asignar la nueva canci�n
            audioFuente.Play(); // Reproducir la nueva canci�n
        }
    }
}
