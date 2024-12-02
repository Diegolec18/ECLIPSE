using UnityEngine;

public class RecogerLibro : MonoBehaviour
{
    public int indiceLibro; // Índice del libro en el HUD
    public LibrosHUD librosHUD;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            librosHUD.RecogerLibro(indiceLibro);
            Destroy(gameObject); // Destruir el libro en la escena
        }
    }
}
