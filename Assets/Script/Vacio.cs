using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vacio"))
        {
            GameManager.Instance.PerderVida();
        }
    }
}
