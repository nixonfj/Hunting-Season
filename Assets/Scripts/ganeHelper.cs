using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganeHelper : MonoBehaviour
{
    public string escenaCreditos;

    // Start is called before the first frame update
    void Start()
    {
        
    }//fin start

    // Update is called once per frame
    void Update()
    {
        
    }//fin upDate

    public void VolverPortada()
    {
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
