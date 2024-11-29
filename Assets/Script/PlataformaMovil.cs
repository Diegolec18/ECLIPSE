using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float desplazamientoX = 6.13f; // Distancia total (30.37 - 24.24)
    public float velocidad = 2f;         // Velocidad de movimiento

    private Vector3 posicionInicial;

    void Start()
    {
        // Guardar la posición inicial del objeto
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcular el nuevo valor de X usando Mathf.PingPong
        float desplazamiento = Mathf.PingPong(Time.time * velocidad, desplazamientoX);
        transform.position = new Vector3(posicionInicial.x - desplazamiento, posicionInicial.y, posicionInicial.z);
    }
}
