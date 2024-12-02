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
    private bool[] librosRecogidos; // Estado de cada libro (recogido o no)

    void Start()
    {
        // Inicializamos los libros como "no recogidos" y el canvas desactivado
        librosRecogidos = new bool[libros.Length];
        canvasVictoria.gameObject.SetActive(false);

        // Establecer los sprites iniciales como "con candado"
        for (int i = 0; i < libros.Length; i++)
        {
            libros[i].sprite = spriteConCandado;
        }
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
        foreach (bool recogido in librosRecogidos)
        {
            if (!recogido)
                return; // Si falta algún libro, no hacemos nada
        }

       
        canvasVictoria.gameObject.SetActive(true);
    }
}
