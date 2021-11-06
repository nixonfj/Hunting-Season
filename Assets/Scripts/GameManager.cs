using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instancia;
    public static GameManager instancia
    {
        get
        {
            return _instancia;
        }
    }
    private void Awake()
    {
        if (instancia == null)
        {
            _instancia = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }//fin del awake

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);

    }//fin del metodo cambiearEscena

    public void salir()
    {
        Application.Quit();
    }//fin de metodo salir

}//fin de la clase
