using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Puerta : MonoBehaviour
{
    public Animator anim;
    public int puertaID; // Identificador único de la puerta
    private bool dentro = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            dentro = true;
        }
    }

    void Update()
    {
        if (dentro && Control_llave.llavesRecogidas.Contains(puertaID))
        {
            anim.SetBool("Abierta", true);
        }
    }
}
