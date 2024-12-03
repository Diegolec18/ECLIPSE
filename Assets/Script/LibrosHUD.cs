using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrosHUD : MonoBehaviour
{
    public Image[] libros; // Arreglo de imágenes de los libros en el HUD
    public Sprite spriteConCandado; // Sprite del libro con candado
    public Sprite spriteNormal; // Sprite del libro normal
    public Canvas canvasVictoria; // Canvas que se activa cuando ganas
    public Canvas canvasHUD; // Canvas del HUD que se desactiva
    public Camera camaraPrincipal; // Cámara principal (actual)
    public Camera camaraSecundaria; // Cámara para la escena de victoria
    public GameObject personajeBailando; // Personaje que baila
    public AudioSource audioFuente; // Fuente de audio para cambiar la música
    public AudioClip nuevaCancion; // Nueva canción que se reproducirá al ganar

    private bool[] librosRecogidos; // Estado de cada libro (recogido o no)
    private bool victoriaAlcanzada = false; // Evita que se active más de una vez

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

        // Aseguramos que la cámara secundaria y el personaje estén desactivados al inicio
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
        // Si ya se activó la victoria, no hagas nada
        if (victoriaAlcanzada) return;

        // Verificar si todos los libros han sido recogidos
        foreach (bool recogido in librosRecogidos)
        {
            if (!recogido)
                return; // Si falta algún libro, no hacemos nada
        }

        // Marcamos que la victoria fue alcanzada
        victoriaAlcanzada = true;

        // Activar el Canvas de Victoria
        if (canvasVictoria != null)
            canvasVictoria.gameObject.SetActive(true);

        // Desactivar el Canvas del HUD
        if (canvasHUD != null)
            canvasHUD.gameObject.SetActive(false);

        // Cambiar a la cámara secundaria
        if (camaraPrincipal != null && camaraSecundaria != null)
        {
            
            camaraSecundaria.enabled = true; // Encender la cámara secundaria
        }

        // Activar el personaje que baila
        if (personajeBailando != null)
            personajeBailando.SetActive(true);

        // Cambiar la música
        if (audioFuente != null && nuevaCancion != null)
        {
            audioFuente.Stop(); // Detener la canción actual
            audioFuente.clip = nuevaCancion; // Asignar la nueva canción
            audioFuente.Play(); // Reproducir la nueva canción
        }
    }
}
