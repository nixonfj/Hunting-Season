using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perderHelper : MonoBehaviour
{

    public string escenaCreditos;

    // Start is called before the first frame update
    void Start()
    {
        
    }//fin del start

    // Update is called once per frame
    void Update()
    {
        
    }//fin del update

    public void VolverPortada()
    {
        Debug.Log("Cambio de escena");
        try
        {
            GameManager.instancia.CambiarEscena(escenaCreditos);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el GameManejer en la escena");
        }
    }

}//fin de la clase
