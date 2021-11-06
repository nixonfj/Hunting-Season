using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditoHelper : MonoBehaviour
{
    public string escenaPortada;
    public void VolverPortada()
    {

        try
        {
            GameManager.instancia.CambiarEscena(escenaPortada);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el GameManejer en la escena");
        }
    }

}//fin de la clase
