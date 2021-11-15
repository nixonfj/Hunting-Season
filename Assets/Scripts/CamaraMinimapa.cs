using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    public Transform jugador;
    void LateUpdate()
    {
        transform.position = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
    }
}
