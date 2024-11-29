using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HUD : MonoBehaviour
{
    public Image[] vidas; 
    public Sprite vidaLlena; 
    public Sprite vidaVacia; 

    
    public void PerderVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].sprite = vidaVacia;
        }
    }

    
    public void GanarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].sprite = vidaLlena;
        }
    }
}
