using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoTiempo : objeto
{

    public bool reposicionar = true;

    public float tiempo;
    public Material positivo;
    public Material negativo;

    public int puntos = 1;
    public GameObject objetoNegativo;

    // Start is called before the first frame update
    void Start()
    {
        if (tiempo > 0)
        {
            this.GetComponent<Renderer>().material = positivo;
        }
        else
        {
            this.GetComponent<Renderer>().material = negativo;
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Le enviamos la operacion de tiempo
            var player = other.GetComponent<Jugador>();
            player.ModificarTiempo(tiempo);

            player.IncrementarPuntaje(puntos);
        }
        if (tiempo > 0)
        {
            if (reposicionar)
            {
                base.OnTriggerEnter(other);

                GameObject.Instantiate(objetoNegativo);
                var objetivoTiempo = objetoNegativo.GetComponent<objetivoTiempo>();
                objetivoTiempo.ReposicionarNuevo();
            }
        }

    }//fin del onTriggerEnter

    public void ReposicionarNuevo()
    {
        base.Reposicionar();

    }//fin del metodo reposicionar

}//fin de la clase
