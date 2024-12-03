using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_llave : MonoBehaviour
{
    public int llaveID; // Identificador único de la llave
    public static HashSet<int> llavesRecogidas = new HashSet<int>(); // Lista de llaves recogidas

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            llavesRecogidas.Add(llaveID);  // Marca la llave como recogida
            gameObject.SetActive(false);  // Desactiva la llave o usa Destroy(gameObject);
        }
    }
}
