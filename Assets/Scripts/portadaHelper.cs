using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portadaHelper : MonoBehaviour
{
    public string escenaJuego;
    public string escenaCreditos;

    public void IniciarJuego()
    {
        try
        {
            GameManager.instancia.CambiarEscena(escenaJuego);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el GameManejer en la escena");
        }

    }//fin del metodo

    public void VerCreditos()
    {
        try
        {
            GameManager.instancia.CambiarEscena(escenaCreditos);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el GameManejer en la escena");
        }
    }//fin del metodo

    public void Salir()
    {
        try
        {
            GameManager.instancia.salir();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el GameManejer en la escena");
        }
    }//fin del metodo

}//fin de la clase
