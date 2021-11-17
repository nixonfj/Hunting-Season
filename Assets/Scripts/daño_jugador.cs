using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño_jugador : MonoBehaviour
{
    public float tiempo;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Jugador>();
            player.ModificarTiempo(tiempo);
        }
    }//fin del onTriggerEnter


}//fin de la clase
